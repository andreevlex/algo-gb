using System;

namespace task1
{
    /*
    1. Реализовать простейшую хэш-функцию. На вход функции подается строка, на выходе сумма кодов символов.
    (c) Alexander Andreev
    */

    class Program
    {
        static int HashFunc(string value)
        {
            int result = 0;
            foreach (var item in value)
            {
                result += (int)item;
                //System.Console.WriteLine((int)item);
            }

            return result;
        }

        static void Main(string[] args)
        {
            string test = "Alexander Andreev";
            System.Console.WriteLine("Тестовая строка {0} и ее хэш функция {1}", test, HashFunc(test));
        }
    }
}
