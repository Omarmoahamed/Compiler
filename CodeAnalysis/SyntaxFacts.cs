using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis
{
    internal static class SyntaxFacts
    {
        public static byte OperatorPrecedence(SyntaxKind kind) 
        {
            switch (kind) 
            {
                case SyntaxKind.PlusToken:
                case SyntaxKind.MinusToken:
                    return 2;

                case SyntaxKind.StarToken:
                case SyntaxKind.SlashToken:
                    return 3;


                case SyntaxKind.EqualEqualToken:
                case SyntaxKind.NotEqualToken:
                case SyntaxKind.SmallerThanToken:
                case SyntaxKind.SmallerOrEqualToken:
                case SyntaxKind.BiggerThanToken:
                case SyntaxKind.BiggerOrEqualToken:
                    return 1;

                default: return 0;
            }
        }
        public static SyntaxKind IdentifierOrKeyword(string word) 
        {
            switch (word) 
            {
                case "for":
                    return SyntaxKind.ForKeyword;

                case "to":
                    return SyntaxKind.ToKeyword;

                case "if":
                    return SyntaxKind.IfKeyword;

                case "while":
                    return SyntaxKind.WhileKeyword;

                case "Do":
                    return SyntaxKind.DoKeyword;

                case "let":
                    return SyntaxKind.LetKeyword;

                case "Number":
                    return SyntaxKind.NumberKeyword;

                case "function":
                    return SyntaxKind.FunctionKeyword;

                case "return":
                    return SyntaxKind.ReturnKeyword;

                case "true":
                    return SyntaxKind.TrueKeyword;

                 case "false":
                    return SyntaxKind.FalseKeyword;

                default:
                    return SyntaxKind.IdentifierToken;
            }
        }
    }
}
