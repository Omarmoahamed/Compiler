using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class DoWhileStatement : Statement
    {
        public DoWhileStatement(SyntaxToken DoKeyword,Statement Body, SyntaxToken WhileKeyword,Expres Condition ) 
        {
            this.DoKeyword = DoKeyword;
            this.Body = Body;
            this.WhileKeyword = WhileKeyword;
            this.Condition = Condition;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
          return  visitor.DoWhileStatement(this);
        }

        public SyntaxKind NodeToken => SyntaxKind.DoWhileStatement;

        public SyntaxToken DoKeyword { get; }

        public Statement Body { get; }

        public SyntaxToken WhileKeyword { get; }

        public Expres Condition { get; }
    }
}
