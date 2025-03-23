using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundWhileStatement : BoundStatement
    {
        public BoundWhileStatement(SyntaxNode syntax, BoundExpression WhileCondition,BoundBlockStatement WhileBody): base(syntax) 
        {
            this.WhileCondition = WhileCondition;
            this.WhileBody = WhileBody;
        }

        public override BoundKind Kind => BoundKind.WhileStatement;

        public BoundExpression WhileCondition { get; }

        public BoundBlockStatement WhileBody { get; }
    }
}
