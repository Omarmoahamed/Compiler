using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class BinaryExpression : Expres
    {

        public BinaryExpression(Expres Left, SyntaxToken Operator, Expres Right) 
        {
            this.Left = Left;
            this.Operator = Operator;
            this.Right = Right;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
              return visitor.VisitBinaryExpres(this);
        }

        public SyntaxKind NodeKind => SyntaxKind.BinaryExpression;
        public Expres Left { get; }
        public SyntaxToken Operator{get;}
        public Expres Right {get; }
    }
}
