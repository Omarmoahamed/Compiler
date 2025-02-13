using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class LiteralExpression : Expres
    {


        public LiteralExpression(SyntaxToken syntaxToken, object? value) 
        {
            this.LiteralToken = syntaxToken;
            this.value = value;
        }
        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.VisitLiteralExpres(this);
        }
        public SyntaxKind NodeKind => SyntaxKind.LiteralExpression;

        public SyntaxToken LiteralToken { get; }

        public object? value { get; }
       
    }
}
