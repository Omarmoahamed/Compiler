using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class FunctionDeclerationStatement : Statement
    {
        public FunctionDeclerationStatement(SyntaxToken FunctionKeyword, 
            SyntaxToken ReturnToken,
            SyntaxToken OpenParaethensisToken,
            ArgumentsSyntaxList<BaseSyntax> Arguments,
            SyntaxToken ClosedParaenthesisToken,
            BlockStatement FunctionBody) 
        {
            this.FunctionKeyword = FunctionKeyword;
            this.ReturnToken = ReturnToken;
            this.OpenParaethesisToken = OpenParaethensisToken;
            this.Arguments = Arguments;
            this.ClosedParaenthesisToken = ClosedParaenthesisToken;
            this.FunctionBody = FunctionBody;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            return visitor.VisitFunctionStatement(this) ;
        }

        public SyntaxKind NodeToken => SyntaxKind.FunctionStatement;
        public SyntaxToken FunctionKeyword { get; }

        public SyntaxToken ReturnToken { get; }

        public SyntaxToken OpenParaethesisToken { get; }

        public ArgumentsSyntaxList<BaseSyntax> Arguments { get; }

        public SyntaxToken ClosedParaenthesisToken { get; }

        public BlockStatement FunctionBody { get; }
    }
}
