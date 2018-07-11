using System;

namespace task10
{
    /*
    10. Дано целое число N (> 0). 
    С помощью операций деления нацело и взятия остатка от деления определить, 
    имеются ли в записи числа N нечетные цифры. Если имеются, то вывести True, если нет — вывести False.
    */
    class Program
    {
        static int GetNumber(string suffix) {
            System.Console.WriteLine($"Введите число {suffix}");
            return Int32.Parse(Console.ReadLine());
        }

        static int GetDigit(ref int number) {
            int digit = number % 10;
            number /= 10;
            return digit;
        }

        static void Main(string[] args)
        {
            int number = GetNumber("N");
            int inner_number = number;
            bool digit_odd = false;

            while (inner_number != 0)
            {
                int digit = GetDigit(ref inner_number);
                if(digit % 2 != 0) {
                    digit_odd = true;
                }
            }

            if(digit_odd) {
                System.Console.WriteLine("Число {0} содержит нечетные цифры", number);
            }
            else
            {
                System.Console.WriteLine("Число {0} не содержит нечетные цифры", number);
            }
        }
    }
}
