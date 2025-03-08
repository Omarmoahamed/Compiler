using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class VariableDeclerator : BaseSyntax
    {
        public VariableDeclerator(SyntaxToken Identifier, EqualClause? EqualClause = null) 
        {
            this.Identifier = Identifier;
           this.EqualClause = EqualClause;
        }

        public SyntaxKind NodeToken => SyntaxKind.VariableDeclerator;

        public SyntaxToken Identifier { get; }

       public EqualClause? EqualClause { get; }
    }
}
