using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class CompilationUnitSyntax : BaseSyntax
    {
        public CompilationUnitSyntax(ImmutableArray<BaseSyntax> ParsedMemebers, SyntaxToken EndOfFile) 
        {
            this.ParsedMembers = ParsedMemebers;
            this.EndOfFile = EndOfFile;

        }

        public SyntaxKind NodeToken => SyntaxKind.CompilationUnit;

        public ImmutableArray<BaseSyntax> ParsedMembers { get; }

        public SyntaxToken EndOfFile { get; }
    }
}
