using System;

namespace task13
{
    /*
    13. * Написать функцию, генерирующую случайное число от 1 до 100.

    с использованием стандартной функции rand()
    без использования стандартной функции rand()
    (c) Alexander Andreev
    */
    class Program
    {
        static int GetRandomNumber1() {
            Random rnd = new Random();
            return rnd.Next(0, 100);
        }

        static int Xn;
        static int Modules = 100;
        static void InitRandom(int m) {
            Xn = DateTime.Now.Millisecond % m;
        }

        static int GetRandomNumber2() {
            int a = 3;
            int b = 7;
            
            Xn = (Xn * a + b) % Modules;
            
            return Xn;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Программа генерации случайных чисел");

            System.Console.WriteLine("Использование стандартного объекта Random");
            for(int i = 0; i < 20; i++) {
                System.Console.WriteLine("{0}", GetRandomNumber1());
            }

            System.Console.WriteLine("Использование своего генератора");
            InitRandom(Modules);
            for (int i = 0; i < 20; i++)
            {
                System.Console.WriteLine("{0}", GetRandomNumber2());   
            }
        }
    }
}
