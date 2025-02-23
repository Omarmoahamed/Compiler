using Memo_Compiler.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class Parser
    {
        private Pool<BaseSyntax> pool = new Pool<BaseSyntax>();

        public SourceText sourceText;

        private DiagnosticsBag diagnosticsBag = new DiagnosticsBag();

        private ImmutableArray<BaseSyntax> tokens;
        private SyntaxToken current => Peek(0);
        public SyntaxToken next => Peek(1);

        private int Position;
        private SyntaxToken Peek(int offset) 
        {
            var pos = Position + offset;
            if(pos> tokens.Length) 
            {
                return new SyntaxToken(SyntaxKind.EndOfFileToken, '\n',tokens.Length, null);
            }
           
            return (SyntaxToken)tokens[pos];
        }

        private SyntaxToken MatchToken(SyntaxKind kind) 
        {
            if (current.kind == kind) 
            {
                return this.Advance();
            }
            
            this.Position++;
            return new SyntaxToken(kind,null,current.position,current.text);
        }
        private SyntaxToken Advance() 
        { 
            var cur = this.current;
            Position++;
            return cur;
        }
        public Parser(SourceText sourceText) 
        {
            this.sourceText = sourceText;
            Position = 0;
            Lexer lex = new Lexer(sourceText);
            SyntaxToken currtoken;
             pool.PoolRent(16);
            do
            {
                currtoken = lex.Lex();   
               
                pool.Add(currtoken);
            } 
            while (currtoken.kind != SyntaxKind.EndOfFileToken);
            this.tokens = ImmutableArray.ToImmutableArray(pool._PooledArray);
            pool.ReturnArr();
        }

        public ImmutableArray<BaseSyntax> ParseSyntaxTokens() 
        {
            pool.PoolRent(16);
            while (this.current.kind != SyntaxKind.EndOfFileToken) 
            {
                var parsed = this.ParseSyntaxToken();
                pool.Add(parsed);

            }

            var ParsedSyntaxTokens = ImmutableArray.ToImmutableArray(pool._PooledArray);
            pool.ReturnArr();
            return ParsedSyntaxTokens;
        }

         
        private BaseSyntax ParseSyntaxToken() 
        {

        }

        private Expres ParseExpression() 
        {

        }
        private Expres ParseBinaryExpression(byte parentprocedence =0) 
        {
            Expres left;
            if (this.current.kind == SyntaxKind.PlusToken && this.current.kind == SyntaxKind.MinusToken) 
            {
                left = ParseUnaryExpression();
            }

            else 
            {
                left = ParsePrimaryExpression();
            }

            bool noStop = true;
            while (noStop) 
            {
                byte procedence = SyntaxFacts.OperatorPrecedence(current.kind);
                if (procedence == 0 || procedence<= parentprocedence) 
                {
                    break;
                }

                var operatortoken = this.Advance();
                var right = this.ParseBinaryExpression();
                left = new BinaryExpression(left, operatortoken, right);

            }

            return left;
        }
        private Expres ParseUnaryExpression() 
        {
            var OperatorKind = current.kind == SyntaxKind.MinusToken ? SyntaxKind.MinusToken : SyntaxKind.PlusToken;
            var Operator = this.MatchToken(OperatorKind);
            var Expres = this.ParseBinaryExpression();

            return new UnaryExpression(Operator, Expres);

        }
        private Expres ParsePrimaryExpression() 
        {
            switch (this.current.kind) 
            {
                case SyntaxKind.OpenParanthesis: return this.ParseOpenParaenthesis();

                case SyntaxKind.NumberToken: return this.ParseNumberLiteral();

                case SyntaxKind.StringToken: return this.ParseStringLiteral();

                case SyntaxKind.TrueKeyword:
                case SyntaxKind.FalseKeyword: return this.ParseBooleanLiteral();
                case SyntaxKind.IdentifierToken when (this.next.kind == SyntaxKind.OpenParanthesis):
                    return this.ParseCallExpression();

                case SyntaxKind.IdentifierToken: return this.ParseNameExpression();

                default: return this.ParseNameExpression();

            }
        }
        private Expres ParseCallExpression() 
        {
            var Identifier = this.MatchToken(SyntaxKind.IdentifierToken);
            var openparaenthesis = this.MatchToken(SyntaxKind.OpenParanthesis);
            var Parameters = this.ParseParametersandArguments();
            var closedparaenthesis = this.MatchToken(SyntaxKind.ClosedParanthesis);

            return new CallExpression(Identifier, openparaenthesis, Parameters, closedparaenthesis);

        }

        private ImmutableArray<BaseSyntax> ParseParametersandArguments() 
        {
            var temp = pool.PoolRent(8);
            var Continue = true;
            while (Continue && current.kind != SyntaxKind.ClosedParanthesis || current.kind != SyntaxKind.EndOfFileToken)
            {
                var expr = this.ParseExpression();
                pool.Add(expr);
                if (this.next.kind == SyntaxKind.SingleComma)
                {
                    var comma = this.MatchToken(SyntaxKind.SingleComma);
                    pool.Add(comma);
                }
                else 
                {
                    Continue = false;
                }
            }

            var arr = ImmutableArray.ToImmutableArray(temp);
            pool.ReturnArr();
            return arr;
        }
        private Expres ParseOpenParaenthesis() 
        {
            var openparaenthesis = this.MatchToken(SyntaxKind.OpenParanthesis);
            var expres = ParseExpression();
            var closedparaenthesis = this.MatchToken(SyntaxKind.ClosedParanthesis);
            return new ParaenthesisExpression(openparaenthesis, expres, closedparaenthesis);

        }
        private Expres ParseStringLiteral() 
        {
            var syntaxtoken = this.MatchToken(SyntaxKind.StringToken);
            return new LiteralExpression(syntaxtoken,syntaxtoken.value);
        }

        private Expres ParseBooleanLiteral() 
        {
            if (current.kind == SyntaxKind.TrueKeyword) 
            {
                var syntaxtoken = this.MatchToken(SyntaxKind.TrueKeyword);
                return new LiteralExpression(syntaxtoken,syntaxtoken.value) ;
            }

            var syntaxtoken2 = this.MatchToken(SyntaxKind.FalseKeyword);
            return new LiteralExpression (syntaxtoken2,syntaxtoken2.value) ;
        }

        private Expres ParseNumberLiteral() 
        {
            var syntaxtoken = this.MatchToken(SyntaxKind.NumberToken);
            return new LiteralExpression(syntaxtoken, syntaxtoken.value) ;
        }

        private Expres ParseNameExpression() 
        {
            var syntaxtoken = this.MatchToken(SyntaxKind.IdentifierToken);
            return new NameExpression(syntaxtoken);

        }

    }
}
