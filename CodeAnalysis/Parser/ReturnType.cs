using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class ReturnType : BaseSyntax
    {
        public ReturnType(SyntaxToken identifier) 
        {
            this.Identifier = identifier;
        }

        public SyntaxKind NodeToken => SyntaxKind.ReturnType;
        public SyntaxToken Identifier { get; }
    }
}
