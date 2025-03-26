using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundGlobalSpace
    {
        public BoundGlobalSpace(BoundGlobalSpace? Previous,FunctionSymbol? MainFunc,ImmutableArray<GlobalVariableSymbol> Gvar,ImmutableArray<FunctionSymbol> Func) 
        {
            this.Previous = Previous;
            this.MainFunction = MainFunc;
            this.GlobalVariables = Gvar;
            this.Functions = Func;
        }
        public BoundGlobalSpace? Previous {  get; }
        public FunctionSymbol? MainFunction { get; }
        public ImmutableArray<GlobalVariableSymbol> GlobalVariables { get; }
        public ImmutableArray<FunctionSymbol> Functions { get; }
    }
}
