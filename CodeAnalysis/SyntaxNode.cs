using Memo_Compiler.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis
{
     abstract class SyntaxNode 
    {
        public int position ;
        public SyntaxKind kind ;
        public Memory<char> value;
        public abstract T accept<T>(Visitor<T> visitor);
    }
}
