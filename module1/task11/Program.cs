using System;

namespace task11
{
    /*
    11. С клавиатуры вводятся числа, пока не будет введен 0.
    Подсчитать среднее арифметическое всех положительных четных чисел, оканчивающихся на 8.
    (c) Alexander Andreev
    */
    class Program
    {
        public static int GetNumber(string hellostring)
        {
            Console.WriteLine(hellostring);
            return Convert.ToInt32(
                Console.ReadLine()
                );
        }

        static void Main(string[] args)
        {
            int value = GetNumber("Введите число");
            int num_cnt = 0;
            int sum = 0;

            while(value != 0)
            {
                if ( value > 0 
                    &&  value % 2 == 0
                    && value % 10 == 8 )
                {
                    //System.Console.WriteLine($"enter value {value}");
                    sum += value;
                    num_cnt += 1;
                }

                value = GetNumber("Введите число");
            }

            Console.WriteLine("Среднее арифметическое четных положительных чисел оканчивающихся на 8 равна {0}",
                sum/num_cnt);

            Console.ReadKey();
        }
    }
}
