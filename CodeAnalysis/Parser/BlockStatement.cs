using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class BlockStatement : Statement
    {
        public BlockStatement(SyntaxToken OpenCurlyBrackets, ImmutableArray<BaseSyntax> body, SyntaxToken CloseCurly) 
        {
            this.OpenCurlyBrackets = OpenCurlyBrackets;
            this.Body = body;
            this.CloseCurlyBrackets = CloseCurly;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.VisitBlockStatement(this);
        }

        public SyntaxKind NodeToken => SyntaxKind.BlockStatement;

        public SyntaxToken OpenCurlyBrackets { get; }

        public ImmutableArray<BaseSyntax> Body { get; }

        public SyntaxToken CloseCurlyBrackets { get; }
    }
}
