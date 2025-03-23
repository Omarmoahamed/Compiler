using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundIfStatement : BoundStatement
    {
        public BoundIfStatement(SyntaxNode syntax,BoundExpression Condition,BoundBlockStatement Body, BoundBlockStatement? Else):base(syntax) 
        {
            this.Condition = Condition;
            this.Body = Body;
            this.ElseClause = Else;

        }
        public override BoundKind Kind => BoundKind.IfStatement;

        

        public BoundExpression Condition { get; }

        public BoundBlockStatement Body { get; }

        public  BoundBlockStatement? ElseClause { get; }
    }
}
