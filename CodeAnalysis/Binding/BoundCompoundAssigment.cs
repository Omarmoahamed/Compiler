using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    // we will use lowering 
    internal class BoundCompoundAssigment : BoundExpression
    {
        public BoundCompoundAssigment(SyntaxNode Syntax,VariableSymbol Variable,BoundBinaryOperatorExpression OpExp,BoundExpression Expression): base(Syntax) 
        {
            this.Type= Expression.Type;
            this.Variable= Variable;
            this.OperatorExpression= OpExp;
            this.Expression= Expression;
        }

        public override BoundKind Kind => BoundKind.AssigmentCompoundExpression;

        public override TypeSymbol Type { get; }

        public VariableSymbol Variable { get; }

        public BoundBinaryOperatorExpression OperatorExpression { get; }

        public BoundExpression Expression { get; }
    }
}
