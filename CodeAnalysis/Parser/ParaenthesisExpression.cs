using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class ParaenthesisExpression : Expres
    {

        public ParaenthesisExpression(SyntaxToken openparaenthesis, Expres expres, SyntaxToken closeparenthesis) 
        {
            this.OpenParenthesis = openparaenthesis;
            this.Expres = expres;
            this.CloseParenthesis = closeparenthesis;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.VisitParaenthesisExpres(this);
        }
        public SyntaxKind NodeKind => SyntaxKind.ParaenthesisiExpression;
        public SyntaxToken OpenParenthesis { get; }
        public Expres Expres { get; }
        public SyntaxToken CloseParenthesis { get; }
    }
}
