using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis
{
    internal abstract class Expres : BaseSyntax
    {
        public abstract T accept<T>(Visitor<T> visitor);
    }
}
