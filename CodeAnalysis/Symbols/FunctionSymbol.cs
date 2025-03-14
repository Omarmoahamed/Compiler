using Memo_Compiler.CodeAnalysis.Parser;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Symbols
{
    internal class FunctionSymbol : Symbol
    {

        public FunctionSymbol(string name,FunctionDeclerationStatement stmt,ImmutableArray<TypeSymbol> Parameters) : base(name) 
        {
            this.stmt = stmt;
            this.Parameters = Parameters;
        }


        public override SymbolKind Kind => SymbolKind.FunctionSymbol;

        public ImmutableArray<TypeSymbol> Parameters { get; }
        public FunctionDeclerationStatement stmt { get; }
    }
}
