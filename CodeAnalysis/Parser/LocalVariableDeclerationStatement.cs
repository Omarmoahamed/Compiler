using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class LocalVariableDeclerationStatement : Statement
    {
        public LocalVariableDeclerationStatement(VariabeleDecleration Decleration, SyntaxToken SemiColon) 
        {
            this.Decleration = Decleration;
            this.SemiColon = SemiColon;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.VisitLocalDeclarationStatemenrt(this);
        }

        public SyntaxKind NodeToken => SyntaxKind.LocalVariableDeclerationStatement;

        public VariabeleDecleration Decleration { get; }

        public SyntaxToken SemiColon { get; }
    }
}
