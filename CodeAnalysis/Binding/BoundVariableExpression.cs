using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundVariableExpression : BoundExpression
    {
        public BoundVariableExpression(SyntaxNode syntax,VariableSymbol variable) : base(syntax) 
        {
            this.Variable = variable;
            this.Type = variable.TypeSymbol;
        }
        public override BoundKind Kind => BoundKind.VariableExpression;
        public override TypeSymbol Type { get; }

       public VariableSymbol Variable { get; }
    }
}
