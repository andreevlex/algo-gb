using System;

namespace task2
{
    /*
    *Реализовать шейкерную сортировку.
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

        static void PrintArray(int[] arr)
        {
            System.Console.Write("[ ");
            foreach (var item in arr)
            {
                System.Console.Write(item + ", ");
            }
            System.Console.WriteLine(" ]");
        }

        static int Sort(ref int[] arr)
        {
            int L, R;
            int count = 0;

            L = 0;
            R = arr.Length - 1;

            while(L <= R) {
                for(int i = R; i > L; i--)
                {
                    count += 1;
                    //System.Console.WriteLine("{0} {1}", i - 1, i);
                    if(arr[i - 1] > arr[i])
                    {
                        Swap(ref arr, i, i - 1);
                    }
                }
                L += 1;

                //PrintArray(arr);

                for(int i = L; i <= R; i++)
                {
                    count += 1;
                    //System.Console.WriteLine("{0} {1}", i - 1, i);
                    if(arr[i - 1] > arr[i])
                    {
                        Swap(ref arr, i -1, i);
                    }
                }
                R -= 1;

                //PrintArray(arr);

                //count += 1;
            }

            return count;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] {7, 4, 6, 11, 9, 3, 8, 10, 5};
            System.Console.WriteLine("Массив до сортировки");
            PrintArray(arr);
            
            int count = Sort(ref arr);
            System.Console.WriteLine("Сортировка выполнена за {0}", count);
            System.Console.WriteLine("Массив после сортировки");
            PrintArray(arr);
            
        }
    }
}
