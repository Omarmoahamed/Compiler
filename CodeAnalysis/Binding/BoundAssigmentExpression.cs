using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundAssigmentExpression : BoundExpression
    {
        public BoundAssigmentExpression(SyntaxToken syntax,VariableSymbol variable,BoundExpression boundExpression) : base(syntax)
        {
           Variable = variable;
            BoundExpression = boundExpression;

        }

        public override BoundKind Kind => BoundKind.AssigmentExpression;

        public override TypeSymbol Type => Variable.TypeSymbol;

        public VariableSymbol Variable { get; }

        public BoundExpression BoundExpression { get; }
        
    }
}
