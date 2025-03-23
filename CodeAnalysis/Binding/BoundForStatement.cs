using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundForStatement : BoundStatement
    {
        public BoundForStatement(SyntaxNode Syntax,VariableSymbol Symbol,BoundExpression Lower,BoundExpression Upper,BoundBlockStatement Body):base(Syntax) 
        {
            this.Variable = Symbol;
            this.LowerBound = Lower;
            this.UpperBound = Upper;
            this.Body = Body;
        }

        public override BoundKind Kind => BoundKind.ForStatement;
        public VariableSymbol Variable { get; }

        public BoundExpression LowerBound { get; }

        public BoundExpression UpperBound { get; }

        public BoundBlockStatement Body { get; }
    }
}
