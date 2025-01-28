using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Text
{
    internal class TextLine
    {
        public TextLine(SourceText sourceText, int startline, int linelength, int lengthincludingbreak)
        {
            SourceText = sourceText;
            StartLine = startline;
            length = linelength;
            LengthIncludingBreak = lengthincludingbreak;
        }
        public SourceText SourceText { get; set; }

        public int StartLine { get; set; }

        public int length { get; set; }
        public int EndLine => StartLine + length;

        public int LengthIncludingBreak { get; set; }

        public TextSpan TextSpan => new TextSpan(StartLine, length);

        public TextSpan SpanIncludingLineBreak => new TextSpan(StartLine, LengthIncludingBreak);


    }
}
