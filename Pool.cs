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
            this.PooledArray = this.A_pool.Rent(minimum);
            this.length = this.PooledArray.Length;
            this.count = 0;
        }
        private readonly ArrayPool<T> A_pool = ArrayPool<T>.Create();
        private readonly int minimum = 8;
        private  int count;  
        private int length;
        public T[] PooledArray;


       

       public T[] PoolRent(int minimum) 
        {
            return A_pool.Rent(minimum);
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

        }

        private void Expand(int arraylength) 
        {
            var temp = this.A_pool.Rent(arraylength * 2);
            Array.Copy(PooledArray, temp, count);
            this.ReturnArr();
            PooledArray = temp;
        }

        public void ReturnArr() 
        {
            this.A_pool.Return(PooledArray,true);
        }
    }
}
