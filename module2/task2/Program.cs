using System;

namespace task2
{
    /*
    2. Реализовать функцию возведения числа a в степень b:
    a. без рекурсии;
    b. рекурсивно;
    c. *рекурсивно, используя свойство чётности степени.
    (c) Alexander Andreev
    */
    class Program
    {
        static int Power1(int num, int stp)
        {
            int p = 1;
            while (stp != 0)
            {
                p *= num;
                stp--;
            }

            return p;
        }

        static int Power2(int num, int stp)
        {
            if(stp == 0)
            {
                return 1;
            }
            return num * Power2(num, stp - 1);
        }

        static int quickPower(int num, int stp)
        {
            int p = 1;

            while(stp != 0)
            {
                if(stp % 2 == 0)
                {
                    num *= num;
                    stp /= 2;
                }
                else
                {
                    p *= num;
                    stp--;
                }
            }

            return p;
        }

        static int quickPowerRec(int num, int stp)
        {
            if(stp == 0)
            {
                return 1;
            }

            if(stp % 2 == 0)
            {
                return quickPowerRec(num * num, stp/2);
            }
            else
            {
                return num * quickPowerRec(num, stp - 1);
            }
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Введите число");
            int num = Int32.Parse(Console.ReadLine());
            
            System.Console.WriteLine("Введите степень");
            int stp = Int32.Parse(Console.ReadLine());

            System.Console.WriteLine("Без рекурсии: число {0} в степени {1} равно {2}", num, stp, Power1(num, stp));
            System.Console.WriteLine("Рекурсия: число {0} в степени {1} равно {2}", num, stp, Power2(num, stp));
            System.Console.WriteLine("Быстрое возведение: число {0} в степени {1} равно {2}", num, stp, quickPower(num, stp));
            System.Console.WriteLine("Быстрое возведение через рекурсию: число {0} в степени {1} равно {2}", num, stp, quickPowerRec(num, stp)); 
        }
    }
}
