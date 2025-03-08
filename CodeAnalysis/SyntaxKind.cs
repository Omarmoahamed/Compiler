using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis
{
    // So tokens are divided into categories: Keywords, Identifiers and Literals(numbers and strings)
    // I will add statments and exprssions for building AST in parser
    public enum SyntaxKind
    {
        OpenCurlyBrackets,
        ClosedCurlyBrackets,
        OpenParanthesis,
        ClosedParanthesis,
        DoupleComma,
        SingleComma,
        SemiColonToken,
        EqualToken,
        EqualEqualToken,
        PluseEqualToken,
        MinusEqualToken,
        StarEqualToken,
        SlashEqualToken,
        MinusToken,
        PlusToken,
        ExclamationToken,
        StarToken,
        SlashToken,
        BiggerThanToken,
        SmallerThanToken,
        BiggerOrEqualToken,
        SmallerOrEqualToken,
        NotEqualToken,
        ColonToken,
        EndOfFileToken,
        NumberToken,
        StringToken,
        IdentifierToken,
        OrToken,
        AndToken,
        PipePipeToken,
        AmpersandAmpersandToken,

        //KeyWords

        IfKeyword,
        ElseKeyword,
        DoKeyword,
        WhileKeyword,
        ReturnKeyword,
        BreakKeyword,
        LetKeyword,
        VarKeyWord,
        ForKeyword,
        ToKeyword,
        FunctionKeyword,
        TrueKeyword,
        FalseKeyword,
        NumberKeyword,
        StringKeyword,
        VoidKeyword,
        UntilKeyword,

        
        BadToken,

            //Expression

        BinaryExpression,
        UnaryExpression,
        AssigmentExpression,
        LiteralExpression,
        ParaenthesisiExpression,
        CallExpression,
        NameExpression,


            //Statement

            IfStatement,
            WhileStatement,
            DoWhileStatement,
            ForStatement,
            ElseClause, // else here is not statement due to because it cannot stand alone and has no condition 
            BreakStatement,
            FunctionStatement,
            BlockStatement, // block here is statement because it can stand alone that group statements 
            ElseStatement, // elsestatement here wraps over elseclause and block statement
            LocalVariableDeclerationStatement,
            ImplicitVariableDecleration,
            ReturnStatement,
            //variable decleration

            VariavleDecleration,
            VariableDeclerator,
            EqualClauseType,

            ParamSyntax,
            ReturnType
    }
}
