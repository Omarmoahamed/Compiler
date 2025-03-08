using Memo_Compiler.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
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

        private BaseSyntax ParseStatement() 
        {
            switch (this.current.kind) 
            {
                case SyntaxKind.OpenCurlyBrackets:
                    return ParseBlockStmt();
                case SyntaxKind.FunctionKeyword:
                    return ParseFunctionDeclaration();
                case SyntaxKind.ForKeyword:
                    return ParseForStatement();
                case SyntaxKind.ReturnKeyword:
                    return ParseReturnStatement();
                case SyntaxKind.IfKeyword:
                    return ParseIfStatement();
                case SyntaxKind.WhileKeyword:
                    return ParseWhileStatement();
                case SyntaxKind.DoKeyword:
                   return ParseDoWhileStatement();
                case SyntaxKind.VarKeyWord:
                   return ParseImplicitlyVariable();
                case SyntaxKind.NumberKeyword:
                case SyntaxKind.StringKeyword:
                   return ParseLocalVariableDeclaration();
               
                    default:
                   return ParseAssigmentExpression();
                

            }

        }

        private Statement ParseLocalVariableDeclaration() 
        {
            var key = this.current.kind == SyntaxKind.StringKeyword ? SyntaxKind.StringKeyword: SyntaxKind.NumberKeyword;
            var KeyWord = this.MatchToken(key);
            var VariableDecleration = ParseMultipleVariables(KeyWord);
            var SemiColon = this.MatchToken(SyntaxKind.SemiColonToken);
            return new LocalVariableDeclerationStatement(VariableDecleration,SemiColon);

        }

        private VariabeleDecleration ParseMultipleVariables(SyntaxToken key) 
        {
            
            while(this.current.kind != SyntaxKind.EndOfFileToken || this.current.kind == SyntaxKind.SemiColonToken) 
            {
                var KeyWord = this.MatchToken(SyntaxKind.IdentifierToken);
                
                if (this.current.kind == SyntaxKind.EqualToken)
                {
                    var Equal = this.MatchToken(SyntaxKind.EqualToken);
                    var Expres = this.ParseAssigmentExpression();
                  var  equal = new EqualClause(Equal, Expres);
                   var declerator = new VariableDeclerator(KeyWord, equal );
                    this.pool.Add(declerator);
                }
                else 
                {
                    this.pool.Add(new VariableDeclerator(KeyWord));
                }
                if (!(this.current.kind == SyntaxKind.SingleComma))
                {
                    break;
                }
                var comma = this.MatchToken(SyntaxKind.SingleComma);
                this.pool.Add(comma);

            }
            var VarDeclaration = new VariabeleDecleration(key, ImmutableArray.Create(this.pool._PooledArray));
            this.pool.ReturnArr();
            return VarDeclaration;
        }
        private Statement ParseImplicitlyVariable() 
        {
            
            var VarKeyword = this.MatchToken(SyntaxKind.VarKeyWord);
            var Identification = this.MatchToken(SyntaxKind.IdentifierToken);
            var EqualToken = this.MatchToken(SyntaxKind.EqualToken);
            var Expres = this.ParseAssigmentExpression();
            return new ImplicitVariableDeclaration(VarKeyword, Identification, EqualToken, Expres);
        }
        private Statement ParseWhileStatement() 
        {
            var WhileKeyword = this.MatchToken(SyntaxKind.WhileKeyword);
            var OpenParaenthesis = this.MatchToken(SyntaxKind.OpenParanthesis);
            var condition = ParseAssigmentExpression();
            var ClosedParaenthesis = this.MatchToken(SyntaxKind.ClosedParanthesis);
            var Block = ParseBlockStmt();
            return new WhileStatement(WhileKeyword, OpenParaenthesis, condition, ClosedParaenthesis, Block);
        }
        private Statement ParseDoWhileStatement() 
        {
            var DoKeyword = this.MatchToken(SyntaxKind.DoKeyword);
            var Block = this.ParseBlockStmt();
            var WhileKeyword = this.MatchToken(SyntaxKind.WhileKeyword);
            var OpenParaenthesis = this.MatchToken(SyntaxKind.OpenParanthesis);
            var condition = ParseAssigmentExpression();
            var ClosedParaenthesis = this.MatchToken(SyntaxKind.ClosedParanthesis);

            return new DoWhileStatement(DoKeyword, Block, WhileKeyword, OpenParaenthesis, condition,ClosedParaenthesis);
        }
        private Statement ParseForStatement() 
        {
            var ForKeyword = this.MatchToken(SyntaxKind.ForKeyword);
            var Identifier = this.MatchToken(SyntaxKind.IdentifierToken);
            var Equal = this.MatchToken(SyntaxKind.EqualToken);
            var LowerBound = ParseAssigmentExpression();
            var UntilKeyword = this.MatchToken(SyntaxKind.UntilKeyword);
            var UpperBound = ParseAssigmentExpression();
            var Block = ParseBlockStmt();

            return new ForStatement(ForKeyword,Identifier, Equal, LowerBound, UntilKeyword,UpperBound,Block);
        }
        private Statement ParseIfStatement() 
        {
            var Keyword = this.MatchToken(SyntaxKind.IfKeyword);
            var OpenParanthesis = this.MatchToken(SyntaxKind.OpenParanthesis);
            var Expres = ParseAssigmentExpression();
            var ClosedParanthesis = this.MatchToken(SyntaxKind.ClosedParanthesis);
            var Block =  (BlockStatement)ParseBlockStmt();
            if (current.kind == SyntaxKind.ElseKeyword) 
            {
                var Else =(ElseStatement) ParseElseStatement();
                return new IfStatement(Keyword, OpenParanthesis, Expres, ClosedParanthesis, Block, Else);
            }

            return new IfStatement(Keyword, OpenParanthesis, Expres, ClosedParanthesis, Block);
        }
        private Statement ParseElseStatement() 
        {
            var Else = this.ParseElseClause();
            var Block = (BlockStatement)ParseBlockStmt();
            return new ElseStatement(Else, Block);
        }

        private ElseClause ParseElseClause() 
        {
            var ElseKeyword = this.MatchToken(SyntaxKind.ElseKeyword);
            return new ElseClause(ElseKeyword);
        }
        private Expres ParseExpression() 
        {
            return ParseAssigmentExpression();
        }
        private Expres ParseAssigmentExpression() 
        {
            if (current.kind == SyntaxKind.IdentifierToken)
            {
              
                switch (Peek(1).kind)
                {
                    case SyntaxKind.EqualToken:
                    case SyntaxKind.PluseEqualToken:
                    case SyntaxKind.MinusEqualToken:
                    case SyntaxKind.StarEqualToken:
                    case SyntaxKind.SlashEqualToken:

                        var identifier = this.MatchToken(SyntaxKind.IdentifierToken);
                        var Operator = this.Advance();
                        var expres = this.ParseExpres();
                        return new AssigmentExpression(identifier, Operator, expres);

                }
            }
            return ParseExpres();
        }
        private Statement ParseFunctionDeclaration() 
        {
            var function = this.MatchToken(SyntaxKind.FunctionKeyword);
            var ReturnType = this.MatchToken(SyntaxKind.IdentifierToken);
            var OpenParenthesis = this.MatchToken(SyntaxKind.OpenParanthesis);
            var Parameters = this.ParseParameters();
            var ClosedParaenthesis = this.MatchToken(SyntaxKind.ClosedParanthesis);
            var BlockStmt = (BlockStatement) this.ParseBlockStmt();
           

            return new FunctionDeclerationStatement(function, ReturnType, OpenParenthesis, Parameters, ClosedParaenthesis, BlockStmt);

        }

        private Statement ParseBlockStmt() 
        {
            var Opencurly = this.MatchToken(SyntaxKind.OpenCurlyBrackets);
            var Body = this.ParseBlockBody();
            var Clusedcurly = this.MatchToken(SyntaxKind.ClosedCurlyBrackets);
            return new BlockStatement(Opencurly,Body,Clusedcurly);
        }

        private Statement ParseReturnStatement() 
        {
            var ReturnKeyword = this.MatchToken(SyntaxKind.ReturnKeyword);
            var Expres = this.ParseAssigmentExpression();
            
            return new ReturnStatement(ReturnKeyword, Expres);
        }
        private ImmutableArray<BaseSyntax> ParseBlockBody() 
        {
            var temp = pool.PoolRent(16);
            while(current.kind == SyntaxKind.EndOfFileToken || current.kind== SyntaxKind.ClosedCurlyBrackets) 
            {
                var stmt = this.ParseStatement();

                pool.Add(stmt);
            }
            var arr = ImmutableArray.Create(temp);
            pool.ReturnArr();
            return arr;
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


        private Expres ParseExpres()
        {
            var left = this.ParseExpresAnd();
            while (this.current.kind == SyntaxKind.PipePipeToken 
             || SyntaxFacts.OperatorPrecedence(this.current.kind) == 1)
            {
                var Operator = this.Advance();
                var right = this.ParseExpresAnd();
                left = new BinaryExpression(left, Operator, right);
            }


            return left;
        }

        private Expres ParseExpresAnd() 
        {
            var left = this.Term();
            while (this.current.kind == SyntaxKind.AmpersandAmpersandToken)
            {
                var Operator = this.Advance();
                var right = this.Term();
                left = new BinaryExpression(left, Operator, right);
            }
            return left ;
        }
        private Expres Term() 
        {
            var left = this.Factor();

            while (SyntaxFacts.OperatorPrecedence(this.current.kind) == 4 )  
            {
                var Operator = this.Advance();
                var right = this.Factor();
                left = new BinaryExpression(left, Operator, right);

            }
            return left;
        }

        
        private Expres Factor() 
        {
            var left = this.ParseUnaryExpression();
          
            while(SyntaxFacts.OperatorPrecedence(this.current.kind)==5 )
            {
                var Operator = this.Advance();
                var right = this.ParseUnaryExpression();
                left = new BinaryExpression(left,Operator, right);
            }
            return left;
            
        }
       
        private Expres ParseUnaryExpression() 
        {
            if (current.kind == SyntaxKind.MinusToken || current.kind == SyntaxKind.ExclamationToken)
            {
                var OperatorKind = current.kind == SyntaxKind.MinusToken ? SyntaxKind.MinusToken : SyntaxKind.PlusToken;
                var Operator = this.MatchToken(OperatorKind);
                var Expres = this.ParseBinaryExpression();

                return new UnaryExpression(Operator, Expres);
            }
            else 
            {
                return this.ParsePrimaryExpression();
            }

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
             pool.PoolRent(8);
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

            var arr = ImmutableArray.ToImmutableArray(this.pool._PooledArray);
            pool.ReturnArr();
            return arr;
        }

        private ImmutableArray<BaseSyntax> ParseParameters() 
        {
            pool.PoolRent(8);
            var Continue = true;
            while (Continue ||current.kind == SyntaxKind.EndOfFileToken || current.kind == SyntaxKind.ClosedParanthesis) 
            {
                var param = this.ParseParam();
                pool.Add(param);
                if (current.kind == SyntaxKind.SingleComma) 
                {
                    pool.Add(param);
                }

                else 
                {
                   Continue = false;
                }

            }

            var arr = ImmutableArray.ToImmutableArray(this.pool._PooledArray);
            pool.ReturnArr();
            return arr;

        }


        private BaseSyntax ParseParam() 
        {
            if (current.kind == SyntaxKind.StringKeyword || current.kind == SyntaxKind.NumberKeyword)
            {
                var parametertype = this.Advance();
                var param = this.MatchToken(SyntaxKind.IdentifierToken);
                return new ParamSyntax(parametertype, param);
            }
            else 
            {
                var parametertype = this.MatchToken(SyntaxKind.VoidKeyword);
                var param = this.MatchToken(SyntaxKind.IdentifierToken);
                return new ParamSyntax(parametertype, param);
            }
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
