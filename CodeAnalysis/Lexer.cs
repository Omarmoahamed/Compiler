using Memo_Compiler.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis
{
    internal class Lexer
    {
        private int position;
        
        private int start;
        private SyntaxKind kind;
        private DiagnosticsBag diagnosticsBag = new DiagnosticsBag();
        private SourceText text;
        private object? value;
        
        public Lexer(SourceText text) 
        {
            this.text = text; 
        }
        private char Current => Peek(0);

        private char Next => Peek(1);
        private char Peek(int offset) 
        {
            int index = position+offset;
            if (index > text.Length) 
            {
                return '\0';
            }
            return text[index];
        }

        public SyntaxToken Lex() 
        {
           start = position;
            ScanToken();
            int length = position - start;  
            
                        return new SyntaxToken(kind,value,position-1,text.TextAsMemory(start,length));
        }


        public bool whitespace() 
        {
            if(Current == ' ') 
            {
                return true;
            }
            return false;
        }

        public void ScanToken() 
        {
            switch (Current) 
            {
                case ';':
                    position++;
                    kind = SyntaxKind.SemiColonToken;
                    break;
                case ',':
                    position++;
                    kind = SyntaxKind.SingleComma;
                    break;
                case '{':
                    position++;
                    kind= SyntaxKind.OpenCurlyBrackets;
                    break;
                   
                case '}':
                    position++;
                    kind = SyntaxKind.ClosedCurlyBrackets;
                    break;
                case '(':
                    position++;
                    kind = SyntaxKind.OpenParanthesis;
                    break;

                case ')':
                    position++;
                    kind = SyntaxKind.ClosedParanthesis;
                    break;
                case '"':

                    position++;
                    String();
                    break;
                case'=' when Peek(1) == '=':
                    position++;
                    kind = SyntaxKind.EqualEqualToken;
                    break;

                case '=':
                    position++;
                    kind = SyntaxKind.EqualToken;
                    break;

                case '!' when Peek(1) == '=':
                    position += 2;
                    kind= SyntaxKind.NotEqualToken;
                    break;
                case '>':
                    if (Peek(1) == '=') 
                    {
                        kind = SyntaxKind.BiggerOrEqualToken;
                        position = +2;
                    }
                    else 
                    {
                        kind = SyntaxKind.BiggerThanToken;
                        position++;
                    }
                    break;
                case '<':
                    if (Peek(1) == '=')
                    {
                        kind = SyntaxKind.SmallerOrEqualToken;
                        position = +2;
                    }
                    else
                    {
                        kind = SyntaxKind.SmallerThanToken;
                        position++;
                    }
                    break;

                case '&' when Peek(1) == '&':
                    kind = SyntaxKind.AndToken;
                    break;
                case '_':
                    ReadIdentifierOrKeyWord();
                    break;

                case '0': case'1': case'2':case'3':case'4':
                case '5':case'6':case'7':case'8':case'9':
                    ReadNumber();
                    position++;
                    break;

                    default:

                    if (char.IsLetter(Current)) 
                    {
                        this.ReadIdentifierOrKeyWord();
                    }
                    else 
                    {
                       kind = SyntaxKind.BadToken;
                        diagnosticsBag.BadCharacter(text.GetIndex(position), Current);
                    }

                    break;


            }

           
        }

        private void String() 
        {
            var sb = new StringBuilder();
            bool end = true;
            while (end) 
            {
                switch (Current) 
                {
                    case '\0':
                    case '\r':
                    case '\n':

                        {
                            diagnosticsBag.IncorrectString(text.GetIndex(position));
                            end = false;
                            break;
                        }

                    case '"' when Peek(1)=='"':
                        
                        
                        position += 2;
                        diagnosticsBag.UnterminatedString(text.GetIndex(position));
                        end = false;
                        break;

                    case '"':
                        position++;
                        end = false;
                        break;

                    default:
                        sb.Append(Current);
                        position++;
                        
                        break;


                }
                kind = SyntaxKind.StringToken;             
               value = sb.ToString();
            }

            
        }

        private void ReadNumber()
        {
            
            bool isdouble = false;
            bool isvalid = true;
            while (char.IsDigit(Current) || Current == '.')
            {
                if (Current == '.')
                {
                    if (char.IsDigit(Peek(1)))
                    {
                        isdouble = true;
                    }
                    else
                    {
                        // error handle
                        isvalid = false;
                        break;


                    }

                }
                position++;
            }

            int length = position - start;
            switch (isdouble)
            {
                case true:
                    if (!double.TryParse(text.TextToSpan(start, length), out var doubleresult))
                    {
                        diagnosticsBag.IncorrectNumber(this.text.GetIndex(position));
                    }
                    this.value = doubleresult;
                    break;

                case false when isvalid == true:
                    if (!int.TryParse(text.TextToSpan(start, length), out var intresult))
                    {
                        diagnosticsBag.IncorrectNumber(this.text.GetIndex(position));
                    }
                    this.value = intresult;

                    break;

                default:
                    diagnosticsBag.IncorrectNumber(this.text.GetIndex(position));
                    value = 0;
                    break;
            }
            this.kind = SyntaxKind.NumberToken;

        }

        private void ReadIdentifierOrKeyWord() 
        {

            
            while (char.IsLetterOrDigit(Current) || Current == '_' ) 
            {
               
                position++;
            }
            
            var length = position - start;
            var _value = text.ToString2(start, length);
            value = _value;
            kind = SyntaxFacts.IdentifierOrKeyword(_value);

        }
       
    }
}
