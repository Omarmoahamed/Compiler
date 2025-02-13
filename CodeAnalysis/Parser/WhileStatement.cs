using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class WhileStatement : Statement
    {
        public WhileStatement(SyntaxToken whileToken, Expres condition, Statement body)
        {
            WhileToken = whileToken;
            Condition = condition;
            Body = body;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.VisitWhileStatement(this);
        }

        public SyntaxKind NodeToken => SyntaxKind.WhileStatement;

        public SyntaxToken WhileToken { get; }

        public Expres Condition { get; }

        public Statement Body { get; }


    }
}
