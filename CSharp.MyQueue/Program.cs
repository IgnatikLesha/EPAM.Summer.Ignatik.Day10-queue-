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
        private int first;
        private int last;
        private const int initCapacity = 16;
        private int queueCapacity;
        private int index = 0;

        //public Queue()
        //{
        //    queueArray = new T[InitCapacity];
        //    First = Last =  0;
        //    QueueCapacity = InitCapacity;
        //}

        public Queue(int length)
        {
            first = 0;
            last = 0;
            queueCapacity = length;
            queueArray = new T[length];
        }

        public void Enqueue(T obj)
        {

            if ((last + 1) % queueCapacity == first % queueCapacity)
            {
                ExpandQueue();
                last = (last + 1) % queueCapacity;
                queueArray[last] = obj;
            }
            else
            {        
                last = (last++) % queueCapacity;
                queueArray[last] = obj;
            }

        }

        private void ExpandQueue()
        {
            T[] NewArray = new T[queueArray.Length * 2];
            for (int i = 0; i < queueCapacity; i++)
            {
                NewArray[i] = queueArray[first];
                first = (first++) % queueArray.Length;
            }
            queueArray = NewArray;
            first = 0;
            last = queueCapacity - 1;
            queueCapacity*=2;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new Exception(string.Format("Queue is empty!"));
            else
            {          
                T value = queueArray[first];   
                queueArray[first] = default(T);
                first = (first++)%queueCapacity;
                return value;
            }
        }


        public bool IsEmpty() => first%queueCapacity == last%queueCapacity;


        public void Clear()
        {
            first = 0;
            last = 0;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception(string.Format("Queue is empty!"));
            else
                return queueArray[first];
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

