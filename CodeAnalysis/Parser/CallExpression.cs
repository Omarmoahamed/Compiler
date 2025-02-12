using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class CallExpression : Expres
    {
        public CallExpression(SyntaxToken IdentifierToken, SyntaxToken OpenParenthesis,ImmutableArray<BaseSyntax> Immutablearray,SyntaxToken ClosedParenthesis) 
        {
            this.IdentifierToken = IdentifierToken;
            this.OpenParaenthesis = OpenParenthesis;
            this.Arguments = new ArgumentsSyntaxList<BaseSyntax>(Immutablearray);
            this.ClosedParaenthesis = ClosedParenthesis;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.visitCallExpres(this);
        }

        public SyntaxKind NodeKind => SyntaxKind.CallExpression;

        public SyntaxToken IdentifierToken { get; }
        public SyntaxToken OpenParaenthesis { get; }
        public ArgumentsSyntaxList<BaseSyntax> Arguments { get; }
        public SyntaxToken ClosedParaenthesis {  get; }
    }
}
