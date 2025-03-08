using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class ImplicitVariableDeclaration : Statement
    {
        public ImplicitVariableDeclaration(SyntaxToken VarKeyWord,SyntaxToken Idintifier,SyntaxToken Equal,Expres Expression) 
        {
            this.VarKeyWord = VarKeyWord;
            this.Identifier = Idintifier;
            this.Equal = Equal;
            this.Expression = Expression;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.VisitImplicitDeclarationStatemenrt(this);
        }

        public SyntaxKind NodeToken => SyntaxKind.ImplicitVariableDecleration;
        public SyntaxToken VarKeyWord { get; }

        public SyntaxToken Identifier { get; }

        public SyntaxToken Equal {  get; }

        public Expres Expression { get; }
    }
}
