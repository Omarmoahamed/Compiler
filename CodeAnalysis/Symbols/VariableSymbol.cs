using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Symbols
{
    internal abstract class VariableSymbol : Symbol
    {
        public VariableSymbol(string name,TypeSymbol typeSymbol,object? value):base(name) 
        {
            TypeSymbol = typeSymbol;
            Value = value;
        }
        
        public TypeSymbol TypeSymbol { get; }
        public object? Value { get; }
    }
}
