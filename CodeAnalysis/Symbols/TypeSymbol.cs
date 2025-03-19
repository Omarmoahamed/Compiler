using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Symbols
{
    internal class TypeSymbol : Symbol
    {
        
        private  TypeSymbol(string name, TypeKind typeKind) : base(name)
        {
            TypeKind = typeKind;
        }

        public override SymbolKind Kind => SymbolKind.TypeSymbol;
        public TypeKind TypeKind { get; }
        public static TypeSymbol Create(SyntaxKind kind,object? value = null) 
        {
            switch (kind) 
            {
                case SyntaxKind.TrueKeyword:
                case SyntaxKind.FalseKeyword:
                    return new TypeSymbol("bool",TypeKind.Bool);
                case SyntaxKind.StringToken:
                    return new TypeSymbol("string",TypeKind.String);
                case SyntaxKind.NumberToken when value is Int32:
                    return new TypeSymbol("number", TypeKind.Int);
                case SyntaxKind.NumberToken when value is double:
                    return new TypeSymbol("number", TypeKind.Double);

                case SyntaxKind.VoidKeyword:
                    return new TypeSymbol("void",TypeKind.Void);
                default:
                   return new TypeSymbol("error",TypeKind.Error);
            }
        }

        public static TypeSymbol CreateType(SyntaxKind kind,TypeKind tkind) 
        {

            return new TypeSymbol(GetName(kind), tkind);
        }

        private static string GetName(SyntaxKind kind,TypeKind? tkind = null) 
        {
            switch (kind) 
            {
                case SyntaxKind.NumberKeyword:
                
                    return "number";
                case SyntaxKind.StringKeyword:
                    return "string";

                case SyntaxKind.TrueKeyword:
                    return "bool";
                default:
                    return "error";
            }
        }
    }
}
