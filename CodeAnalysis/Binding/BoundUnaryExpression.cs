using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundUnaryExpression : BoundExpression
    {
        public BoundUnaryExpression(SyntaxNode syntax,BoundUnaryOperator Operator,BoundExpression operand): base(syntax) 
        {
            this.Type = Operator.Type;
            this.Operator = Operator;
            this.Operand = operand;
        }

        public override BoundKind Kind => BoundKind.UnaryExpression;

        public override TypeSymbol Type { get; }
        public BoundUnaryOperator Operator { get; }
        public BoundExpression Operand { get; }
    }
}
