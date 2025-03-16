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

        public FunctionSymbol(string name,TypeSymbol Type,FunctionDeclerationStatement stmt,ImmutableArray<ParameterSymbol> Parameters) : base(name) 
        {
            this.stmt = stmt;
            this.Parameters = Parameters;
            this.Type = Type;
            if(Type.Name == "void") 
            {
                IsVoid = true;
            }

            IsVoid = false;
        }


        public override SymbolKind Kind => SymbolKind.FunctionSymbol;

        public ImmutableArray<ParameterSymbol> Parameters { get; }
        public FunctionDeclerationStatement stmt { get; }
        public TypeSymbol Type { get; } 

        public bool IsVoid { get; }
    }
}
