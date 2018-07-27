using System;

namespace task4
{
    /*
    4. *Создать функцию, копирующую односвязный список
    (то есть создает в памяти копию односвязного списка, без удаления первого списка).
    (c) Alexander Andreev
    */
    
    class TNode<T>
    {
       public T value;
       public TNode<T> pred; 
    }

    class MyList<T>
    {
        public TNode<T> head;
    }

    class Program
    {

        static void Add<T>(MyList<T> self, T value)
        {
            TNode<T> node = new TNode<T>();
            node.pred = self.head;
            node.value = value;

            self.head = node;
        }

        static void AddBack<T>(MyList<T> self, T value)
        {
            TNode<T> node = new TNode<T>();
            node.pred = null;
            node.value = value;

            var tail = self.head;
            if (tail == null)
            {
                self.head = node;
                return;    
            }

            while(tail.pred != null)
            {
                tail = tail.pred;
            }

            tail.pred = node;
        }

        static MyList<T> CreateCopy<T>(MyList<T> list)
        {
            MyList<T> result = new MyList<T>();

            var element = list.head;

            while(element != null)
            {
                AddBack(result, element.value);
                element = element.pred;
            }

            return result;
        } 

        static void PrintMyList<T>(MyList<T> list)
        {
            var element = list.head;
            System.Console.Write("[ ");
            while(element != null)
            {
                System.Console.Write(element.value + ", ");
                element = element.pred;
            }
            System.Console.Write(" ]");
            System.Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var list1 = new MyList<int>();
            Add(list1, 1);
            Add(list1, 2);
            Add(list1, 3);         

            PrintMyList(list1);

            var list2 = CreateCopy(list1);

            PrintMyList(list2);   
        }
    }
}
