using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Symbols
{
    internal class GlobalVariableSymbol:VariableSymbol
    {
        public GlobalVariableSymbol(string name,TypeSymbol TybeSymbol,object? Value):base(name, TybeSymbol,Value)
        {

        }

        public override SymbolKind Kind => SymbolKind.Global;
    }
}
