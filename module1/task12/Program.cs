using System;

namespace task12
{
    /*
    12. Написать функцию нахождения максимального из трех чисел.
    (c) Alexandex Andreev
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

        static int GetMaxFromNumbers(int num1, int num2, int num3) {
            int max1 = Max(num1, num2);
            return Max(max1, num3);
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Программа поиска максимума из 3-х чисел");
            int num1 = GetNumber();
            int num2 = GetNumber();
            int num3 = GetNumber();

            System.Console.WriteLine("Из чисел [{0}, {1}, {2}] максимальное {3}", num1, num2, num3, GetMaxFromNumbers(num1, num2, num3));
        }
    }
}
