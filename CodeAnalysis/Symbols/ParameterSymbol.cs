using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Symbols
{
    internal class ParameterSymbol : Symbol
    {
        public ParameterSymbol(string name, TypeSymbol typeSymbol) : base(name)
        {
            TypeSymbol = typeSymbol;
        }

        public override SymbolKind Kind => SymbolKind.ParamSymbol;

        public TypeSymbol TypeSymbol { get; }
    }
}
