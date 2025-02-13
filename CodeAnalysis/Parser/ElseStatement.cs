using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class ElseStatement : Statement
    {
        public ElseStatement(ElseClause elseClause, SyntaxToken openParaenthesis, BlockStatement blockStatement)
        {
            ElseClause = elseClause;
            OpenParaenthesis = openParaenthesis;
            BlockStatement = blockStatement;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.VisitElseStatement(this);
        }

        public ElseClause ElseClause { get; }

        public SyntaxToken OpenParaenthesis { get; }

        public BlockStatement BlockStatement { get; }
    }
}
