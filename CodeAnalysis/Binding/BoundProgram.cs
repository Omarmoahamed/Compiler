using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundProgram
    {

        public BoundProgram(BoundProgram? Previous,FunctionSymbol MainFunc, ImmutableDictionary<FunctionSymbol, BoundBlockStatement> FunctionBodies) 
        {
            this.Previous = Previous;
            this.MainFunction = MainFunc;
            this.FunctionBodies = FunctionBodies;
        }
        public BoundProgram? Previous {  get; }
        public FunctionSymbol? MainFunction { get; }

        public ImmutableDictionary<FunctionSymbol,BoundBlockStatement> FunctionBodies { get; }
    }
}
