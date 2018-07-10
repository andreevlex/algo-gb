using System;

namespace task14
{
    /*
    14. * Автоморфные числа. Натуральное число называется автоморфным, если оно равно последним
    цифрам своего квадрата. Например, 25 \ :sup: `2` = 625. Напишите программу, которая вводит
    натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.
    (c) Alexander Andreev
    */
    class Program
    {
        static long NumLength(long number)
        {
            long len = 0;
            long inner = number;
            while(inner > 0) {
                inner /= 10;
                len += 1;
            }

            return len;
        }

        static long Ten(long number) {
            long result = 1;
            for(long i = 0; i < number; i++){
                result *= 10;
            }

            return result;
        }

        static bool isAutomorph(long number) {
            var nums = NumLength(number);
            var dec = Ten(nums);
            if( number == (number * number) % (dec) ) {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Программа поиска Автоморфных чисел");
            System.Console.WriteLine("Введите число N");
            long number = Convert.ToInt64(Console.ReadLine());

            for(long i = 0; i < number; i++) {
                if(isAutomorph(i)) {
                    System.Console.WriteLine("Автоморфное число {0}", i);
                }
            } 
        }
    }
}
