using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSharp.MyQueue
{
    class QIterator<T>: IEnumerator<T>
    {


            public T[] arr;
            int position = -1;

            public bool MoveNext()
            {
                if (position == arr.Length - 1)
                {
                    Reset();
                    return false;
                }
                position++;
                return true;
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return arr[position];
                }
            }

            public T Current
            {
                get
                {
                    return arr[position];
                }
            }


            public QIterator(T[] list)
            {
                arr = list;
            }

            public void Dispose() { }
    
    }
}
