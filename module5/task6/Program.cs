using System;

namespace task6
{
    /*
    6. *Реализовать очередь.
    (c) Alexander Andreev
    */
    class MyQueue
    {
        public int [] inner;
        public int first;
        public int last;

        public MyQueue(int len)
        {
            inner = new int[len + 1];
            first = 1;
            last = 0;
        }
    }

    class Program
    {
        static void Add(MyQueue self, int value)
        {
            if(self.last < self.inner.Length - 1)
            {
                self.last += 1;
                self.inner[self.last] = value;
            }
            else
            {
                throw new Exception("Очередь полная");
            }
        }

        static bool IsEmpty(MyQueue self)
        {
            if( self.last < self.first)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
 
        static int GetValue(MyQueue self)
        {
            if(IsEmpty(self))
            {
                throw new Exception("Очередь пуста!");
            }

            int result = self.inner[self.first];

            for (int i = self.first; i < self.last; i++)
            {
                self.inner[i] = self.inner[i + 1];
            }

            self.last -= 1;

            return result;
        }

        static void Main(string[] args)
        {
            var q = new MyQueue(5);
            Add(q, 1);
            Add(q, 2);
            Add(q, 3);
            Add(q, 4);
            Add(q, 5);
            //Add(q, 6);
            
            while(!IsEmpty(q))
            {
                System.Console.WriteLine(GetValue(q));
            }
        }
    }
}
