using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Symbols
{
    internal class TypeSymbol : Symbol
    {
        public  TypeSymbol(string name) : base(name) 
        {
        }

        public override SymbolKind Kind => SymbolKind.TypeSymbol;

        public static TypeSymbol Create(SyntaxKind kind) 
        {
            switch (kind) 
            {
                case SyntaxKind.TrueKeyword:
                case SyntaxKind.FalseKeyword:
                    return new TypeSymbol("bool");
                case SyntaxKind.StringToken:
                    return new TypeSymbol("string");
                case SyntaxKind.NumberToken:
                    return new TypeSymbol("number");
                case SyntaxKind.VoidKeyword:
                    return new TypeSymbol("void");
                default:
                   return new TypeSymbol("error");
            }
        }
    }
}
