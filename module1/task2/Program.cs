using System;

namespace task2
{
    /*
    2. Найти максимальное из четырех чисел. Массивы не использовать.
    (c) Alexander Andreev
    */
    class Program
    {
        static int GetNumber() {
            System.Console.WriteLine("Введите число");
            return Int32.Parse(Console.ReadLine());
        }

        static int Max(int num1, int num2) {
            int result;

            if(num1 > num2) {
                result = num1;
            }
            else {
                result = num2;
            }

            return result;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Программа поиска максимума из четырех чисел");
            int num1 = GetNumber();
            int num2 = GetNumber();
            int num3 = GetNumber();
            int num4 = GetNumber();

            int max1 = Max(num1, num2);
            int max2 = Max(num3, num4);
            int real_max = Max(max1, max2);

            System.Console.WriteLine("Максимум из чисел [{0}, {1}, {2}, {3}] равно {4}", 
            num1, num2, 
            num3, num4,
            real_max);
        }
    }
}
