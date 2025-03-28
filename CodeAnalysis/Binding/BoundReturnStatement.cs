using Memo_Compiler.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Binding
{
    internal class BoundReturnStatement : BoundStatement
    {
        public BoundReturnStatement(SyntaxNode syntax,BoundExpression? ReturnExpres):base(syntax) 
        {
            this.ReturnExpression = ReturnExpres;
        }

        public override BoundKind Kind => BoundKind.ReturnStatement;

        

        public BoundExpression? ReturnExpression { get; }
    }
}
