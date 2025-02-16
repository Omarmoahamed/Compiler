using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class VariableDeclerator : BaseSyntax
    {
        public VariableDeclerator(SyntaxToken Identifier, SyntaxToken? EqualToken, Expres? Expression) 
        {
            this.Identifier = Identifier;
            this.EqualToken = EqualToken;
            this.Expression = Expression;
        }

        public SyntaxKind NodeToken => SyntaxKind.VariableDeclerator;

        public SyntaxToken Identifier { get; }

        public SyntaxToken? EqualToken {  get; }

        public Expres? Expression { get; }
    }
}
