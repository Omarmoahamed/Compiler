using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class VariabeleDecleration : BaseSyntax
    {
        public VariabeleDecleration(SyntaxToken Keyword,ImmutableArray<BaseSyntax> arr ) 
        {
            this.Keyword = Keyword;
            this.Declerators = new ArgumentsSyntaxList<BaseSyntax>(arr);
        }

        public SyntaxKind NodeToken => SyntaxKind.VariavleDecleration;

        public SyntaxToken Keyword { get; }

        public ArgumentsSyntaxList<BaseSyntax> Declerators { get; }

        
    }
}
