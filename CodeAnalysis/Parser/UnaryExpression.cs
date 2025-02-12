using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class UnaryExpression : Expres
    {
        public UnaryExpression(SyntaxToken operatortoken, Expres operand) 
        {
            this.OperatorToken = operatortoken;
            this.Operand = operand;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.visitUnaryExpres(this);
        }

        private SyntaxKind NodeKind => SyntaxKind.UnaryExpression;
        private SyntaxToken OperatorToken { get; }
        private Expres Operand { get; }

    }
}
