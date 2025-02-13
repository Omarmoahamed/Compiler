using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class ElseClause
    {
        public ElseClause(SyntaxToken ElseToken) 
        {
            this.ElseToken = ElseToken;
        }

        public SyntaxKind NodeKind => SyntaxKind.ElseClause;
        public SyntaxToken ElseToken { get; }

    }
}
