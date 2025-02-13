using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class AssigmentExpression : Expres
    {
        public AssigmentExpression(SyntaxToken IdentifierToken, SyntaxToken AssignToken, Expres Expression) 
        {
            this.IdentifierToken = IdentifierToken;
            this.AssignToken = AssignToken;
            this.Expression = Expression;
        }
        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.VisitAssigmentExpres(this);
        }
        public SyntaxKind NodeToken => SyntaxKind.AssigmentExpression;
        public SyntaxToken IdentifierToken { get; }
        public SyntaxToken AssignToken { get; }
        public Expres Expression { get; }
    }
}
