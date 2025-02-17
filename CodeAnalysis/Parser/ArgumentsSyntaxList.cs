using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Sockets;
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
           return new Enumerator(this.Arguments);
        }

        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }




        internal struct Enumerator : IEnumerator<T>
        {
          
            public ImmutableArray<T> list;
            public T _current;
            public T Current => _current;
            public int position;
            public Enumerator(ImmutableArray<T> list)
            {
                this.list = list;
                this.position = 0;
                this._current = list[position];
            }

            T IEnumerator<T>.Current => _current ;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                if(position >= list.Length) 
                {
                   
                    return false;
                }
                _current = list[position];
                position++;
                return true;
            }

            public void Reset()
            {
               position = 0;
            }
        }
    }

   
}
