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
        T VisitAssigmentExpres(AssigmentExpression Expres);

        T VisitBinaryExpres(BinaryExpression Binary);
        T VisitCallExpres(CallExpression Expres);
        T VisitLiteralExpres(LiteralExpression Expres);
        T VisitParaenthesisExpres(ParaenthesisExpression Expres);
        T VisitUnaryExpres(UnaryExpression Expres);
        T VisitNameExpres(NameExpression Expres);
       

        T VisitBlockStatement(BlockStatement Block);
        T VisitForStatement(ForStatement For);
        T VisitReturnStatement(ReturnStatement ReturnStatement);
        T VisitElseStatement(ElseStatement ElseStmt);

        T VisitIfStatement(IfStatement IfStmt);

        T VisitWhileStatement(WhileStatement WhileStmt);

        T DoWhileStatement(DoWhileStatement DoWhileStmt);

        T VisitFunctionStatement(FunctionDeclerationStatement FunctionStmt);
        T VisitLocalDeclarationStatemenrt(LocalVariableDeclerationStatement LocalDeclerationStmt);
    }
}
