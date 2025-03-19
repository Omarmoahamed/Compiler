using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal enum BinaryKind
    {
        Adding,
        Subtraction,
        Multiplication,
        Division,
        EqualEqual,
        NotEqual,
        BiggerEqual,
        LessEqual,
        Greate,
        Smaller
    }
}
