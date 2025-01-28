using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis
{
    internal class Diagnostic
    {
        private readonly string message;

        private readonly int Line;

        private Diagnostic(string message, int line)
        {
            this.message = message;
            this.Line = line;
        }

        public static Diagnostic Error(string message, int line)
        {
            return new Diagnostic(message, line);
        }
    }
}
