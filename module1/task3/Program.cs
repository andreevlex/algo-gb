using System;

namespace task3
{
    /*
    3. Написать программу обмена значениями двух целочисленных переменных:
    a. с использованием третьей переменной;
    (c) Alexander Andreev
    */
    class Program
    {
        static int GetNumber() {
            System.Console.WriteLine("Введите число");
            return Int32.Parse(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Программа обмена переменных с использованием третьей переменной");
            int num1 = GetNumber();
            int num2 = GetNumber();

            System.Console.WriteLine("Числа до операции замены число1: {0}; число2: {1}", num1, num2);
            
            int tmp = num1;
            num1 = num2;
            num2 = tmp;   

            System.Console.WriteLine("Числа после операции замены число1: {0}; число2: {1}", num1, num2);
        }
    }
}
