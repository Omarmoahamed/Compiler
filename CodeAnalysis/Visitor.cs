using Memo_Compiler.CodeAnalysis.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis
{
    internal interface Visitor<T> 
    {
        T visitAssigmentExpres(AssigmentExpression Expres);

        T VisitBinaryExpres(BinaryExpression Binary);
        T visitCallExpres(CallExpression Expres);
        T visitLiteralExpres(LiteralExpression Expres);
        T visitParaenthesisExpres(ParaenthesisExpression Expres);
        T visitUnaryExpres(UnaryExpression Expres);

    }
}
