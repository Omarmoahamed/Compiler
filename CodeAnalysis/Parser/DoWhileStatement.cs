using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class DoWhileStatement : Statement
    {
        public DoWhileStatement(SyntaxToken DoKeyword,Statement Block, SyntaxToken WhileKeyword, SyntaxToken OpenParaenthesis, Expres Condition , SyntaxToken ClosedParaenthesis) 
        {
            this.DoKeyword = DoKeyword;
            this.Block = Block;
            this.WhileKeyword = WhileKeyword;
            this.OpenParaenthesis = OpenParaenthesis;
            this.Condition = Condition;
            this.ClosedParaenthesis = ClosedParaenthesis;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
          return  visitor.DoWhileStatement(this);
        }

        public SyntaxKind NodeToken => SyntaxKind.DoWhileStatement;

        public SyntaxToken DoKeyword { get; }

        public Statement Block { get; }

        public SyntaxToken WhileKeyword { get; }
        public SyntaxToken OpenParaenthesis { get; }
        public Expres Condition { get; }

        public SyntaxToken ClosedParaenthesis { get; }
    }
}
