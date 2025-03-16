using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundScope
    {
        private BoundScope? Parent;

        public BoundScope(BoundScope parent) 
        { 
            Parent = parent; 
        }

        private Dictionary<string, Symbol>? Symbols;

        public bool AddSymbol(Symbol symbol) 
        {
            if (Symbols == null) 
            {
                Symbols = new Dictionary<string, Symbol>();
                Symbols.Add(symbol.Name, symbol);
                return true;
            }

            if (Symbols.ContainsKey(symbol.Name)) 
            {
               return false;
            }
            else 
            {
                Symbols.Add(symbol.Name, symbol); return true;
            }
        }

        public Symbol? FindSymbol(string name) 
        {
            if (Symbols != null && Symbols.TryGetValue(name, out var symbol)) 
            {
                return symbol;
            }

           return this.Parent?.FindSymbol(name);
        }
    }
}
