using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundLiteralExpression : BoundExpression
    {

        public BoundLiteralExpression(SyntaxToken token,TypeSymbol type) : base(token) 
        {
            this.Type = type;
        }
        public override BoundKind Kind => BoundKind.LiteralExpression;

        public override TypeSymbol Type { get; }

    }
}
