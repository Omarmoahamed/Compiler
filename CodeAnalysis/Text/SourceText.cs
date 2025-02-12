using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Text
{
    internal class SourceText
    {
        private readonly string text;

        private ImmutableArray<TextLine> lines;
        
        public int Length => text.Length;
        public char this[int index]=> text[index];

        private string filename;

        private SourceText(string text, string filename)
        {
            this.text = text;
            this.filename = filename;
        }

        public ReadOnlySpan<char> TextToSpan(int start,int length) 
        {
            ReadOnlySpan<char> textsp = this.text.AsSpan(start,length);
            return textsp;
        }
        public ReadOnlyMemory<char> TextAsMemory(int start,int length) 
        {
            return text.AsMemory(start,length);
        }
        public string ToString2(int start, int length) 
        {
           return this.text.Substring(start, length);
        }
        public static SourceText From(string text, string filename)
        {
            return new SourceText(text, filename);
        }

        private static ImmutableArray<TextLine> ParseLines(string text, SourceText sourceText)
        {
            var lines = ImmutableArray.CreateBuilder<TextLine>();

            var linestart = 0;
            var position = 0;

            while (position < text.Length)
            {
                var linebreakwidth = GetBreakWidthLength(text, position);
                if (linebreakwidth == 0)
                {
                    position++;
                }
                else
                {
                    var linelength = position - linestart;
                    var lengthincludingbreak = linelength + linebreakwidth;
                    var textline = new TextLine(sourceText, linestart, linelength, lengthincludingbreak);
                    lines.Add(textline);

                    position += linebreakwidth;
                    linestart = position;

                }

              
            }

            if (position >= text.Length)
            {
                var linelength = position - linestart;

                var line = new TextLine(sourceText, linestart, linelength, linelength);
                lines.Add(line);

            }

            return lines.ToImmutableArray();
        }


        private static int GetBreakWidthLength(string text, int position)
        {
            var current = text[position];

            var next = position + 1 >= text.Length ? '\0' : text[position + 1];

            if (current == '\r' && next == '\n')
            {
                return 2;
            }
            if (current == '\r' || current == '\n')
            {
                return 1;
            }

            return 0;
        }
        //binary search with two pointers
        public int GetIndex(int position)
        {
            var low = 0;
            var high = lines.Length - 1;

            while (low <= high)
            {
                var index = low +(high-low) / 2;

                if (lines[index].StartLine == position) 
                {
                    return index;
                }
                if (lines[index].StartLine > position)
                {
                    high = index - 1;
                }
                else 
                {
                    low = index + 1;
                }


            }
            return low - 1;
        }
    }
}
