using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class IfStatement : Statement
    {
        public IfStatement(SyntaxToken If,SyntaxToken OpenParaenthesis, Expres Condition, SyntaxToken ClosedParaenthesis, BlockStatement Body,ElseStatement? Else = null) 
        {
            this.IfKeyword = If;
            this.OpenParaenthesis = OpenParaenthesis;
            this.Condition = Condition;
            this.ClosedParaenthesis = ClosedParaenthesis;
            this.Body = Body;
            this.OptionalElse = Else;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
           
            return visitor.VisitIfStatement(this);
        }

        public SyntaxKind NodeToken => SyntaxKind.IfStatement;

        public SyntaxToken IfKeyword { get; }
        public SyntaxToken OpenParaenthesis { get; }

        public Expres Condition { get; }

        public SyntaxToken ClosedParaenthesis { get; }

        public BlockStatement Body { get; }

        public ElseStatement? OptionalElse { get; }
    }
}
