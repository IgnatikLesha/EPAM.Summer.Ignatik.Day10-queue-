using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.MyQueue
{

    public class Queue<T>: IEnumerable<T>
    {
        private T[] queueArray ;
        private int First { get; set; }
        private int Last { get; set; }
        private const int InitCapacity = 16;
        private int QueueCapacity;
        private int index = 0;

        //public Queue()
        //{
        //    queueArray = new T[InitCapacity];
        //    First = Last =  0;
        //}

        public Queue(int length)
        {
            First = 0;
            Last = 0;
            QueueCapacity = length;
            queueArray = new T[length];
        }

        public void Enqueue(T obj)
        {

            if ((Last++) % QueueCapacity == First % QueueCapacity)
            {
                ExpandQueue();
                Last = (Last++) % QueueCapacity;
                queueArray[Last] = obj;
                QueueCapacity++;
            }
            else
            {        
                Last = (Last++) % QueueCapacity;
                queueArray[Last] = obj;
                QueueCapacity++;
            }

        }

        private void ExpandQueue()
        {
            T[] NewArray = new T[queueArray.Length * 2];
            for (int i = 0; i < QueueCapacity; i++)
            {
                NewArray[i] = queueArray[First];
                First = (First++) % queueArray.Length;
            }
            queueArray = NewArray;
            First = 0;
            Last = QueueCapacity - 1;
            QueueCapacity*=2;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new Exception(string.Format("Queue is empty!"));
            else
            {          
                T value = queueArray[First];   
                queueArray[First] = default(T);
                First = (First++) % QueueCapacity;
                QueueCapacity--;
                return value;
            }
        }


        public bool IsEmpty() {
            if (QueueCapacity == 0)
                return true;
            else
                return false;
        }

        public void Clear()
        {
            First = 0;
            Last = 0;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception(string.Format("Queue is empty!"));
            else
                return queueArray[First];
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new QIterator<T>(queueArray);
        }





        }
    }

