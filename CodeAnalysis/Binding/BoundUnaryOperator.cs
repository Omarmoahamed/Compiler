using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal sealed class BoundUnaryOperator
    {


        public BoundUnaryOperator(BoundUnaryKind kind, TypeSymbol symbol) 
        {
            this.Kind = kind;
            this.Type = symbol;
            this.OperandType = symbol;
        }

        public TypeSymbol Type { get; }
        public TypeSymbol OperandType { get; }
        public BoundUnaryKind Kind { get; }

        private static Dictionary<(SyntaxKind SKind, TypeKind TKind), (BoundUnaryKind UKind, TypeSymbol TSymbol)> UOperators =
            new Dictionary<(SyntaxKind SKind, TypeKind TKind), (BoundUnaryKind UKind, TypeSymbol TSymbol)>
            {
                {(SyntaxKind.ExclamationToken,TypeKind.Bool),(BoundUnaryKind.Logical,TypeSymbol.CreateType(SyntaxKind.TrueKeyword,TypeKind.Bool)) },
                {(SyntaxKind.MinusToken,TypeKind.Int),(BoundUnaryKind.Negation,TypeSymbol.CreateType(SyntaxKind.NumberKeyword,TypeKind.Int)) },
                {(SyntaxKind.MinusToken,TypeKind.Double),(BoundUnaryKind.Negation,TypeSymbol.CreateType(SyntaxKind.NumberKeyword,TypeKind.Double)) },
                {(SyntaxKind.PlusToken,TypeKind.Int),(BoundUnaryKind.Identity,TypeSymbol.CreateType(SyntaxKind.NumberKeyword,TypeKind.Int)) },
                {(SyntaxKind.PlusToken,TypeKind.Double),(BoundUnaryKind.Identity,TypeSymbol.CreateType(SyntaxKind.NumberKeyword,TypeKind.Double)) },

            };

        public static BoundUnaryOperator CreateUnaryOperator(SyntaxKind SKind, TypeKind TKind) 
        {
            var data = UOperators[(SKind, TKind)];

            return new BoundUnaryOperator(data.UKind, data.TSymbol);
        }
    }
}
