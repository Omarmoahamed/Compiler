using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler.CodeAnalysis.Parser
{
    internal class ArgumentsSyntaxList<T> : IEnumerable<T> where T : BaseSyntax
    {
        public ArgumentsSyntaxList(ImmutableArray<T> Aguments) 
        {
            this.Arguments = Aguments;
        }


        public ImmutableArray<T> Arguments { get; }

        public T this[int index] => Arguments[index*2];

        public int Length => Arguments.Length+1/2;

        public BaseSyntax GetSeparator(int index)
        {
            if (index < 0 || index >= Length - 1)
                throw new ArgumentOutOfRangeException(nameof(index));

            return Arguments[index * 2 + 1];
        }
        public ImmutableArray<T> GetArgumentsWithSeperators() => this.Arguments;
        
        // it works here due to it return object under the hood of yield 
        public  IEnumerator<T> GetEnumerator() 
        {
            for (int i = 0; i < this.Length; i++) 
            {
                yield return this.Arguments[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }
    }
}
