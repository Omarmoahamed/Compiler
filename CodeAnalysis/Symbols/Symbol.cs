using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Symbols
{
    internal abstract class Symbol
    {
        public Symbol(string name) 
        {
            Name = name;
        }
        public string Name { get;  }
        public abstract SymbolKind Kind { get; }
    }
}
