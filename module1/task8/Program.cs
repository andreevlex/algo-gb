using System;

namespace task8
{
    /*
    8. Ввести a и b и вывести квадраты и кубы чисел от a до b.
    (c) Alexander Andreev
    */
    class Program
    {
        static int GetNumber(string suffix) {
            System.Console.WriteLine($"Введите {suffix}");
            return Int32.Parse(Console.ReadLine());
        }

        static int Power(int num, int stp)
        {
            int p = 1;
            while (stp > 0)
            {
                p = p * num;
                stp--;
            }
            
            return p;
        }

        static void PrintPower(int a, int b, int stp)
        {
            for(int i = a; i < b; i++)
            {
                int result = Power(i, stp);
                System.Console.WriteLine("Число {0} в степени {1} равно {2}", i, stp, result);
            }
        }

        static void Main(string[] args)
        {
            int a = GetNumber("a");
            int b = GetNumber("b");
            
            PrintPower(a, b , 2);
            PrintPower(a, b, 3);
        }
    }
}
