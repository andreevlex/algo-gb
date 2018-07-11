using System;

namespace task5
{
    /*
    5. С клавиатуры вводится номер месяца. Требуется определить, к какому времени года он относится.
    (c) Alexander Andreev
    */
    class Program
    {
        static int GetNumber(string suffix) {
            System.Console.WriteLine($"Введите {suffix}");
            return Int32.Parse(Console.ReadLine());
        }

        static void Main(string[] args)
        {
           int m = GetNumber("номер месяца");
           
           switch (m)
           {
               case 1:
               case 2:
               case 12:
               System.Console.WriteLine("Месяц с номером {0} относится к Зиме", m);
               break;
               
               case 3:
               case 4:
               case 5:
               System.Console.WriteLine("Месяц с номером {0} относится к Весне", m);
               break;

               case 6:
               case 7:
               case 8:
               System.Console.WriteLine("Месяц с номером {0} относится к Лету", m);
               break;
               
               case 9:
               case 10:
               case 11:
               System.Console.WriteLine("Месяц с номером {0} относится к Осени", m);
               break;
               
               default:
               System.Console.WriteLine("Введен некорректный номер месяца. Допустимы только с 1 по 12");
               break;
           }
        }
    }
}
