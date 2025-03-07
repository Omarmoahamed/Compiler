using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class WhileStatement : Statement
    {
        public WhileStatement(SyntaxToken whileToken, SyntaxToken OpenParaenthesis, Expres condition, SyntaxToken ClosedParaenthesis, Statement body)
        {
            WhileToken = whileToken;
            this.OpenParaenthesis = OpenParaenthesis;
            Condition = condition;
            this.ClosedParaenthesis = ClosedParaenthesis;
            Body = body;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.VisitWhileStatement(this);
        }

        public SyntaxKind NodeToken => SyntaxKind.WhileStatement;

        public SyntaxToken WhileToken { get; }
        public SyntaxToken OpenParaenthesis {  get; }
        public Expres Condition { get; }
        public SyntaxToken ClosedParaenthesis { get; }
        public Statement Body { get; }


    }
}
