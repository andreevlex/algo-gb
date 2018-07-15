using System;

namespace task1
{
    /*
    1. Реализовать функцию перевода из 10 системы в двоичную используя рекурсию.
    (c) Alexander Andreev
    */
    class Program
    {
        static int Dec2Bin(int num)
        {
            int bin = 0;
            int k = 1;

            while(num > 0)
            {
                bin += (num % 2) * k;
                k *= 10;
                num /= 2;
            }

            return bin;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Программа перевода из 10 в 2 систему исчисления");
            int num = Int32.Parse(Console.ReadLine());
            int bin = Dec2Bin(num);

            System.Console.WriteLine("Число {0} в двоичной системе равно {1}", num, bin);
        }
    }
}
