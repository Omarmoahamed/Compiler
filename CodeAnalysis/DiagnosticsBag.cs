using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis
{
    public class DiagnosticsBag 
    {
        
        private readonly List<Diagnostic> _diagnostics = new();
        
            
        public DiagnosticsBag() { }

        private void ReportError(int line , string message) 
        {
          var error =  Diagnostic.Error(message, line);
            _diagnostics.Add(error);
        }
        public void IncorrectNumber(int line) 
        {
            var message = $"The number in line {line} isn't valid";
            ReportError(line, message);

        }
        public void IncorrectString(int line) 
        {
            var message = $"The string is invalid in line {line}";
            ReportError(line, message);
        }

        public void BadCharacter(int line, char character) 
        {
            var message = $"The character {character} is not defined in line {line}";
            ReportError(line, message);
        }

    }
}
