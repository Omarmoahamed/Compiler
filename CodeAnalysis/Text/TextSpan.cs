using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Text
{
    internal struct TextSpan
    {

        public TextSpan(int start, int length)
        {
            this.start = start;
            this.length = length;
        }
        public int start { get; }
        public int length { get; }

        public int end => start + length;

        public static TextSpan FromBounds(int start, int end)
        {
            var length = end - start;
            return new TextSpan(start, length);
        }

        public bool OverlapsWith(TextSpan span)
        {
            return start < span.end &&
                   end > span.start;
        }

        public override string ToString() => $"{start}..{end}";





    }
}
