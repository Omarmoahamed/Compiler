using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class ForStatement : Statement
    {
        public ForStatement(SyntaxToken ForKeyword,SyntaxToken Identifier,SyntaxToken Equal,Expres LowerBound,SyntaxToken UntilKey,Expres UpperBound,Statement Body) 
        {
            this.ForKeyword = ForKeyword;
            this.Identitfier = Identifier;
            this.Equal = Equal;
            this.LowerBound = LowerBound;
            this.UntilKeyword = UntilKey;
            this.UpperBound = UpperBound;
            this.Body = Body;
        }

       

        public override T accept<T>(Visitor<T> visitor)
        {
             
            return visitor.VisitForStatement(this);
        }

        public SyntaxKind NodeToken => SyntaxKind.ForStatement;
       public SyntaxToken ForKeyword { get; }
        public SyntaxToken Identitfier { get; }

        public SyntaxToken Equal {  get; }
        public Expres LowerBound { get; }

        public SyntaxToken UntilKeyword { get; }

        public Expres UpperBound { get; }

        public Statement Body { get; }
    }
}
