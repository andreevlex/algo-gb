using System;

namespace task3
{
    /*
    3. Написать программу, которая определяет, является ли введенная скобочная последовательность правильной.
    Примеры правильных скобочных выражений: (), ([])(), {}(), ([{}]), неправильных — )(, ())({), (, ])}), ([(]) для скобок [,(,{.

    Например: (2+(2*2)) или [2/{5*(4+7)}]
    (c) Alexander Andreev
    */
    class TNode<T>
    {
       public T value;
       public TNode<T> pred; 
    }

    class MyStack<T> 
    {
       public TNode<T> head;
       public int count; 
    }

    class Program
    {
        static void Push<T>(MyStack<T> stack, T value)
        {
            TNode<T> node = new TNode<T>();
            node.value = value;
            node.pred = stack.head;

            stack.head = node;
            stack.count += 1;
        }

        static T Pop<T>(MyStack<T> stack)
        {
            TNode<T> _head = stack.head;

            if(_head == null)
            {
                throw new Exception("Стэк пуст!");
            }

            stack.head = _head.pred;
            stack.count -= 1;

            var result = _head.value;

            return  result;
        }

        static bool StackEmpty<T>(MyStack<T> stack)
        {
            return stack.head == null;
        }

        static bool CheckSkobka(string text)
        {
             MyStack<char> stack = new MyStack<char>();
             var skobki = new string[] {"{}", "()", "[]"};
             bool result = false;
             foreach(var item in text)
             {
                 foreach(var skobka in skobki)
                 {
                     if(item == skobka[0])
                     {
                         Push(stack, item);
                     }
                     if(item == skobka[1])
                     {
                         if(StackEmpty(stack))
                         {
                             result = false;
                             continue;
                         }
                         var data = Pop(stack);
                         char para = '\0';
                         foreach(var skobka2 in skobki)
                         {
                             if(skobka2[1] == item)
                             {
                                 find = true;
                                 para = skobka2[0];
                             }
                         }
                         if(data == para)
                         {
                            result = true;
                         }
                     }
                 }
             }
             
             return result;
        }

        static void Main(string[] args)
        {
            string test1 = "(2+(2*2))";
            string test2 = "(, ])})";

            MyStack<string> stack = new MyStack<string>();
            Push(stack, "2");
            System.Console.WriteLine(Pop(stack));

            var result1 = CheckSkobka(test1);
            System.Console.WriteLine("Для выражения {0} результат проверки скобок равен {1}", test1, result1);

            var result2 = CheckSkobka(test2);
            System.Console.WriteLine("Для выражения {0} результат проверки скобок равен {1}", test2, result2);
        }
    }
}
