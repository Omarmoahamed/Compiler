using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class VariabeleDecleration : BaseSyntax
    {
        public VariabeleDecleration() 
        {

        }

        public SyntaxKind NodeToken => SyntaxKind.VariavleDecleration;

        public SyntaxToken Keyword { get; }

        public ArgumentsSyntaxList<VariableDeclerator> Declerators { get; }

        
    }
}
