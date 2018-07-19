using System;

namespace task3
{
    /*
    3. Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив. 
    Функция возвращает индекс найденного элемента или -1, если элемент не найден.
    (c) Alxander Andreev
    */
    class Program
    {
        static int BinarySearch(ref int[] arr, int x)
        {
            if(arr.Length == 0 || x < arr[0] || x > arr[arr.Length - 1])
            {
                return -1; // нет смысла искать
            }

            int first = 0;
            int last = arr.Length - 1;

            int mid = first + (last - first) / 2;
            while( first <= last && arr[mid] != x)
            {
                if(arr[mid] < x)
                {
                    first = mid + 1;
                }
                else
                {
                    last = mid - 1;
                }

                mid = first + (last - first) / 2;
            }

            if(arr[mid] == x)
            {
                return mid;
            }
            else
            {
                return -1;
            }
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] {1, 3, 5, 7, 9, 11, 13, 15};
            int result = BinarySearch(ref arr, 11);
            if(result == -1)
            {
                System.Console.WriteLine("Число {0} не найдено", 11);
            }
            else
            {
                System.Console.WriteLine("Число найдено по индексу {0}", result);
            }
        }
    }
}
