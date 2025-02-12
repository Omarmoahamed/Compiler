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
        MinusToken,
        PlusToken,
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

        //KeyWords

        IfKeyword,
        ElseKeyword,
        DoKeyword,
        WhileKeyword,
        ReturnKeyword,
        BreakKeyword,
        LetKeyword,
        ForKeyword,
        ToKeyword,
        FunctionKeyword,
        TrueKeyword,
        FalseKeyword,

        
        BadToken,

            //Expression

        BinaryExpression,
        UnaryExpression,
        AssigmentExpression,
        LiteralExpression,
        ParaenthesisiExpression,
        CallExpression,
        LogicalExpression,


            //Statement

            IfStatement,
            WhileStatement,
            ForStatement,
            ElseStatement,
            BreakStatement,
            FunctionStatement


    }
}
