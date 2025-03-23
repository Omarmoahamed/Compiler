using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundVariableDecleration : BoundStatement
    {
        public BoundVariableDecleration(SyntaxNode syntax,VariableSymbol Variable,BoundExpression Initializer): base(syntax) 
        {
            this.Variable = Variable;
            this.Initializer = Initializer;
        }

        public override BoundKind Kind => BoundKind.VariableDecleration;
        public VariableSymbol Variable { get; }
        public BoundExpression? Initializer { get; }
    }
}
