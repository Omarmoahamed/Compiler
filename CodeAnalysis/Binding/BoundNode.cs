using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal abstract class BoundNode
    {
        public BoundNode(SyntaxNode syntaxToken)
        {
            SyntaxToken = syntaxToken;
        }

        public abstract BoundKind Kind { get; }
        public SyntaxNode SyntaxToken { get; }
    }
}
