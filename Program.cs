using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            for (int i = 0; i < 10; i++) 
                list.Add(i);
            
            foreach (int r in list)
            {
                Console.WriteLine(r);
            }
            
            Console.WriteLine("----------");
            Console.WriteLine("Adding");
            list.Add(5);
            
            foreach (int r in list) 
            {
                Console.WriteLine(r);
            }
            var b = list[0];
            Console.WriteLine("index 0 = " + b);
            Console.WriteLine("Size = " +list.Count);
        }

        class MyList<T> : IEnumerable, IEnumerator
    {
        int count = 0;
        public int Count { get => count; }

        T[] mass = new T[1]; 

        int position = -1; 
        int pos = -1; 

        public void Clear() 
        {
            mass = new T[1];
            count = 0;
            pos = -1;
        }

        public void Add(T mass) 
        {
            count++;  
            Array.Resize(ref this.mass, count);
            pos++; 
            this.mass[pos] = mass; 

        }

        public bool MoveNext() 
        {
            position++;
            return (position < mass.Length);
        }

        public void Reset() 
        {
            position = -1;
        }
        public T Current
        {
            get { try { return mass[position];}catch (IndexOutOfRangeException) { throw new InvalidOperationException();}}
        }


        object IEnumerator.Current 
        {
            get{ return Current;}
        }


        public IEnumerator GetEnumerator()
        {
            return mass.GetEnumerator();
        }

        public T this[int index]  
        {
            get { return mass[index]; }
            set { mass[index] = value; }
        }
    } 
    }
}