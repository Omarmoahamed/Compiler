using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class EqualClause : BaseSyntax
    {
        public EqualClause(SyntaxToken EqualToken, Expres Expression) 
        {
            this.EqualToken = EqualToken;
            this.Expression = Expression;
        }

        public SyntaxKind NodeToken => SyntaxKind.EqualClauseType;

        public SyntaxToken EqualToken { get; }

        public Expres Expression { get; }
    }
}
