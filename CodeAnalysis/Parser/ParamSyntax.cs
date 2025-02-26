using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class ParamSyntax : BaseSyntax
    {
        public ParamSyntax(SyntaxToken typetoken, SyntaxToken identifier) 
        {
            this.TypeToken = typetoken;
            this.IdentifierToken = identifier;
        }

        public SyntaxKind NodeToken => SyntaxKind.ParamSyntax;

        public SyntaxToken TypeToken { get; }

        public SyntaxToken IdentifierToken { get; }
    }
}
