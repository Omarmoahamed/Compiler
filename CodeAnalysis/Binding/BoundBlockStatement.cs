using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundBlockStatement : BoundStatement
    {
        public BoundBlockStatement(SyntaxNode syntax, ImmutableArray<BoundStatement> BoundStatements):base(syntax) 
        {
            this.BoundStatements = BoundStatements;
        }

        public override BoundKind Kind => BoundKind.BlockStatement;

        public ImmutableArray<BoundStatement> BoundStatements { get; }
    }
}
