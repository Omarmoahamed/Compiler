using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis
{
    public sealed class SyntaxToken
    {

        public int position { get; }
        public SyntaxKind kind { get; }
        public object? value {  get; }

        public string text { get; }

        public SyntaxToken(SyntaxKind kind, object? value,int position,string text) 
        {
            this.kind = kind;
            this.value = value;
            this.position = position;
            this.text = text;
        }
    }
}
