using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class ReturnStatement : Statement
    {
        public ReturnStatement(SyntaxToken ReturnKeyword, Expres Expression) 
        {
            this.ReturnKeyword = ReturnKeyword;
            this.Expression = Expression;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.VisitReturnStatement(this);
        }

        public SyntaxKind NodeToken => SyntaxKind.ReturnStatement;
        public SyntaxToken ReturnKeyword { get; }
        public Expres Expression { get; }
    }
}
