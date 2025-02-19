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

        private ImmutableArray<SyntaxToken> tokens;

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
            Position = pos;
            return tokens[pos];
        }
        public Parser(SourceText sourceText) 
        {
            this.sourceText = sourceText;
            Position = 0;
            Lexer lex = new Lexer(sourceText);
            SyntaxToken currtoken;
            var temparr = ImmutableArray.CreateBuilder<SyntaxToken>();
            do
            {
                currtoken = lex.Lex();   
               
                temparr.Add(currtoken);
            } 
            while (currtoken.kind != SyntaxKind.EndOfFileToken);
            this.tokens = temparr.ToImmutableArray<SyntaxToken>();
        }
    }
}
