using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class GlobalStatement : Statement
    {
        public GlobalStatement(Statement statement)
        {
            Statement = statement;
        }

        public override T accept<T>(Visitor<T> visitor)
        {
            throw new NotImplementedException();
        }

        public SyntaxKind NodeToken => SyntaxKind.GlobalStatement;

        public Statement Statement { get; }
    }
}
