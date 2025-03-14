using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Symbols
{
    internal class LocalVariableSymbol: VariableSymbol
    {
        public LocalVariableSymbol(string name,TypeSymbol TypeSymbol,object? value):base(name,TypeSymbol,value) 
        {

        }

        public override SymbolKind Kind => SymbolKind.Local;
    }
}
