using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Symbols
{
    internal enum SymbolKind
    {
        ParamSymbol,
        FunctionSymbol,
        TypeSymbol,
        Local,
        Global
    }
}
