using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class NameExpression : Expres
    {
        public NameExpression(SyntaxToken IdentifierToken) 
        {
            this.IdentifierToken = IdentifierToken;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.VisitNameExpres(this);
        }

        public SyntaxKind NodeToken => SyntaxKind.NameExpression;

        public SyntaxToken IdentifierToken { get; }
    }
}
