using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class StatementExpression : Statement
    {
        public StatementExpression(Expres expression)
        {
            Expression = expression;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            throw new NotImplementedException();
        }
        public SyntaxKind NodeToken => SyntaxKind.StatementExpression;

        public Expres Expression { get; }
    }
}
