using System;

namespace task7
{
    /*
    7. С клавиатуры вводятся числовые координаты двух полей шахматной доски (x1,y1,x2,y2).
    Требуется определить, относятся ли к поля к одному цвету или нет.
    (c) Alexander Andreev
    */

    public struct MyPoint
    {
        public int x;
        public int y;
    }

    enum MyColor {
        White = 0,
        Black
    }

    class Program
    {
        static int GetNumber(string suffix) {
            System.Console.WriteLine($"Введите {suffix}");
            return Int32.Parse(Console.ReadLine());
        }

        static MyColor GetColor(MyPoint point)
        {
            if( (point.x + point.y) % 2 == 0 )
            {
                return MyColor.Black;
            }
            else
            {
                return MyColor.White;
            }
        }
        static bool EqColor(MyPoint p1, MyPoint p2)
        {
            return GetColor(p1) == GetColor(p2);
        }

        static void Main(string[] args)
        {
            MyPoint p1 = new MyPoint();
            MyPoint p2 = new MyPoint();
  
            p1.x = GetNumber("координату x1");
            p1.y = GetNumber("координату y1");
            System.Console.WriteLine("p1 цвета {0}", GetColor(p1));

            p2.x = GetNumber("координату x2");
            p2.y = GetNumber("координату y2");
            System.Console.WriteLine("p2 цвета {0}", GetColor(p2));

            if(EqColor(p1, p2))
            {
                System.Console.WriteLine("Клетки одинакового цвета");
            }
            else 
            {
                System.Console.WriteLine("Клетки разного цвета");           
            }
        }
    }
}
