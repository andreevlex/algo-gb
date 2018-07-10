using System;

namespace task1
{
/*
    1. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела по формуле I=m/(h*h); где
    m-масса тела в килограммах, h - рост в метрах.
 */
 // (c) Alexander Andreev
    class Program
    {
        static double BMI(double mass, double height)
        {
            return mass/(height * height);
        }
        static void Main(string[] args)
        {
            System.Console.WriteLine("Программа рассчета индекса массы тела");
            System.Console.WriteLine("Введите массу тела.");
            double m = Double.Parse(Console.ReadLine());

            System.Console.WriteLine("Введите рост.");
            double h = Double.Parse(Console.ReadLine());

            if(h == 0) {
                System.Console.WriteLine("Вы ввели ошибочный рост");
                Environment.Exit(-1);
            }

            System.Console.WriteLine("Ваш индекс массы тела равен {0:F}", BMI(m, h));
        }
    }
}
