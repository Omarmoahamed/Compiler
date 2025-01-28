using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis
{
    internal static class SyntaxFacts
    {
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
