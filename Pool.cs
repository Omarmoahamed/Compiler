using Memo_Compiler.CodeAnalysis;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memo_Compiler
{
    public class Pool<T> where T : BaseSyntax
    {
        public Pool() 
        {
           
            this.count = 0;
        }
        private readonly ArrayPool<T> A_pool = ArrayPool<T>.Create();
        private readonly int minimum = 8;
        private  int count;  
        private int length;
        private T[] PooledArray;
        private Stack<(int count, int lenght, T[] arr)> ArrPropStack = new Stack<(int count, int lenght, T[] arr)>();

        public T[] _PooledArray => this.PooledArray;



       

       public T[] PoolRent(int minimum) 
        {
            if (PooledArray is not null && ArrPropStack.Count >= 0)
            {
                this.ArrPropStack.Push((count, length, PooledArray));
            }
            PooledArray = A_pool.Rent(minimum);

            this.length = PooledArray.Length;
            return PooledArray;

        }

        public void Add(T item) 
        {
            if(count < length) 
            {
                PooledArray[count] = item;
                count++;
                return;
            }

            Expand(length);
            PooledArray[count] = item;
            count++;

        }

        private void Expand(int arraylength) 
        {
            var temp = this.ExpandRent(length*2);
            
            this.ExpandReturn();
            PooledArray = temp;
            length = PooledArray.Length;
        }

        private T[] ExpandRent(int lenght) 
        {
            var temp = this.A_pool.Rent(lenght);
            Array.Copy (PooledArray, temp, lenght);
            return temp;
        }
        private void ExpandReturn() 
        {
            this.A_pool.Return(PooledArray, true);

        }
        public void ReturnArr() 
        {
            if (this.ArrPropStack.Count > 0)
            {
                this.A_pool.Return(PooledArray, false);
                var temp = this.ArrPropStack.Pop();
                this.PooledArray = temp.arr;
                this.length = temp.lenght;
                this.count = temp.count;
            }
            else
            {
                this.A_pool.Return(PooledArray, false);
                PooledArray = null;
                length = 0;
            }
        }
    }
}
