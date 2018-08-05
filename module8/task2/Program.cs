using System;

namespace task2
{
    /*
    Реализовать быструю сортировку.
    (c) Alexander Andreev
    */
    class Program
    {
        static int partition(int[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    int temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }

        static void quicksort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end);
            quicksort(array, start, pivot - 1);
            quicksort(array, pivot + 1, end);
        }

        static void Print(int[] arr)
        {
            System.Console.Write("[ ");
            foreach(var item in arr)
            {
                System.Console.Write(item + ", ");
            }

            System.Console.WriteLine(" ]");
        }

        static void Main(string[] args)
        {
            var arr = new int[10];
            var rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 1000);
            }

            Print(arr);

            quicksort(arr, 0, arr.Length - 1);
            Print(arr);

        }
    }
}
