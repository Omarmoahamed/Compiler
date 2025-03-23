using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundDoWhileStatement:BoundStatement
    {
        public BoundDoWhileStatement(SyntaxNode syntax,BoundBlockStatement DoBody,BoundExpression WhileCondition) : base(syntax) 
        {
            this.DoBody = DoBody;
            this.WhileCondition = WhileCondition;

        }

        public override BoundKind Kind => BoundKind.DoWhileStatement;
        public BoundBlockStatement DoBody { get; }

        public BoundExpression WhileCondition { get; }
    }
}
