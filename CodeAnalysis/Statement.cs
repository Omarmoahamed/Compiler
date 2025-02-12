using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis
{
    internal abstract class Statement : BaseSyntax
    {
        public abstract T accept<T>(Visitor<T> visitor) where T : BaseSyntax;
    }
}
