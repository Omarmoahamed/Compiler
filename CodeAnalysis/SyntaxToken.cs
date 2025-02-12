using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis
{
    public sealed class SyntaxToken : BaseSyntax
    {

        public int position { get; }
        public SyntaxKind kind { get; }
        public object? value {  get; }

        public ReadOnlyMemory<char> text { get; }

        public SyntaxToken(SyntaxKind kind, object? value,int position, ReadOnlyMemory<char> text) 
        {
            this.kind = kind;
            this.value = value;
            this.position = position;
            this.text = text ;
        }
    }
}
