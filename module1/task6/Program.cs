using System;

namespace task6
{
    /*
    6. Ввести возраст человека (от 1 до 150 лет) и вывести его вместе с последующим словом «год», «года» или «лет».
    (c) Alexander Andreev
    */
    class Program
    {
        static int GetNumber(string suffix) {
            System.Console.WriteLine($"Введите {suffix}");
            return Int32.Parse(Console.ReadLine());
        }

        static string GetSuffix(int age)
        {
            if(age > 10 && age < 15)
            {
                return "лет";
            }

            switch (age % 10)
            {
                case 1:
                return "год";
                case 2:
                case 3:
                case 4:
                return "года"; 
                default:
                return "лет";
            }
        }

        static void Main(string[] args)
        {
            int age = GetNumber("возраст");

            if(age < 0 || age > 150)
            {
                System.Console.WriteLine("Введен неверный возраст");
            }
            else
            {
                System.Console.WriteLine($"Человеку {age} {GetSuffix(age)}");       
            }
        }
    }
}
