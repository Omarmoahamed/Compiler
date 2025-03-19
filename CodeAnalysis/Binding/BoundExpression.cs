using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal abstract class BoundExpression : BoundNode
    {
        public BoundExpression(SyntaxNode syntax): base(syntax) 
        {

        }
        public abstract TypeSymbol Type { get; }
    }
}
