using System;

namespace task1
{
    /*
    1. Попробовать оптимизировать пузырьковую сортировку. 
    Сравнить количество операций сравнения оптимизированной и не оптимизированной программы. 
    Написать функции сортировки, которые возвращают количество операций.
    (c) Alexander Andreev
    */
    class Program
    {
        static void Swap(ref int[] arr, int a, int b)
        {
            int tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }

        static int Sort1(ref int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr, j, j + 1);

                    }
                    count += 1;
                }
                count += 1;
            }

            return count;
        }

        static int Sort2(ref int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                bool sorted = true;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr, j, j + 1);
                        sorted = false;
                    }

                    count += 1;
                }
                if (sorted)
                {
                    break;
                }
                count += 1;
            }

            return count;
        }
        static void PrintArray(int[] arr)
        {
            System.Console.Write("[ ");
            foreach (var item in arr)
            {
                System.Console.Write(item + ", ");
            }
            System.Console.WriteLine(" ]");
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 4, 5, 7, 9, 12, 2, 8 };
            System.Console.WriteLine("Массив до сортировки");
            PrintArray(arr);
            int count = Sort1(ref arr);
            System.Console.WriteLine("Сортировка выполнена за {0}", count);
            System.Console.WriteLine("Массив после сортировки");
            PrintArray(arr);

            int[] arr2 = new int[] { 1, 4, 5, 7, 9, 12, 2, 8 };
            System.Console.WriteLine("Массив до сортировки");
            PrintArray(arr2);
            
            int count2 = Sort2(ref arr2);
            System.Console.WriteLine("Оптимизированная сортировка выполнена за {0}", count2);
            System.Console.WriteLine("Массив после сортировки");
            PrintArray(arr2);
        }
    }
}
