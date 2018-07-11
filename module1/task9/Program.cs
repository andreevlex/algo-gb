using System;

namespace task9
{
    /*
    9. Даны целые положительные числа N и K.
    Используя только операции сложения и вычитания,
    найти частное от деления нацело N на K, а также остаток от этого деления.
    (с) Alexander Andreev
    */
    class Program
    {
        static int GetNumber(string suffix) {
            System.Console.WriteLine($"Введите число {suffix}");
            return Int32.Parse(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            int n = GetNumber("N");
            int k = GetNumber("K");

            int chastnoe = 0;

            while (n >= k)
            {
                chastnoe += 1;
                n = n - k;   
            }

            int ostatok = n;

            System.Console.WriteLine("Частное {0}", chastnoe);
            System.Console.WriteLine("Остаток от деления {0}", ostatok);            
        }
    }
}
