using System;

namespace task4
{
    /*
    4. Написать программу нахождения корней заданного квадратного уравнения
    (с) Alexander Andreev
    */

    enum Roots
    {
        None = 0,
        One,
        Two
    }

    class Program
    {
        static Roots Calc(double a, double b, double c, out double x1, out double x2) {
           double D = Math.Pow(b, 2) - 4 * a * c;
           
           if (D > 0)
           {
               x1 = (-b + Math.Sqrt(D)) / (2 * a);
               x2 = (-b - Math.Sqrt(D)) / (2 * a);
               return Roots.Two;
           }

           if(D == 0) 
           {
              x1 = (-b + Math.Sqrt(D)) / (2 * a);
              x2 = 0; 
              return Roots.One;
           }
           
           x1 = 0;
           x2 = 0;
           return Roots.None;

        }

        static double GetNumber(string suffix) {
            System.Console.WriteLine($"Введите число {suffix}");
            return Double.Parse(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Программа вычисления корней квадратного уравнения");
            double a = GetNumber("a");
            double b = GetNumber("b");
            double c = GetNumber("c");

            double x1;
            double x2;

            Roots result = Calc(a, b, c, out x1, out x2);

            if( result == Roots.Two) 
            {
                Console.WriteLine("x1= {0}\nx2= {1}", x1, x2);
            }
            else if(result == Roots.One) 
            {
                Console.WriteLine("Уравнение имеет один корень x= {0}", x1);
            }
            else if(result == Roots.None) 
            {
                Console.WriteLine("Действительных корней нет");
            }
        }
    }
}
