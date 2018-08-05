using System;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    /*
    3. *Реализовать сортировку слиянием.
    (c) Alexander Andreev
    */
    class Program
    {
        static int[] Merge_Sort(int[] massive)
       {
           if (massive.Length == 1)
            {
                return massive;
            }
           int mid_point = massive.Length / 2;
           return Merge(Merge_Sort(massive.Take(mid_point).ToArray()), Merge_Sort(massive.Skip(mid_point).ToArray()));
       }
 
       static int[] Merge(int[] mass1, int[] mass2)
       {
           int a = 0, b = 0;
           int[] merged = new int[mass1.Length + mass2.Length];
           for (int i = 0; i < mass1.Length + mass2.Length; i++)
           {
               if (b < mass2.Length && a < mass1.Length)
                   if (mass1[a] > mass2[b])
                       merged[i] = mass2[b++];
                   else //if int go for
                       merged[i] = mass1[a++];
               else
                   if (b < mass2.Length)
                       merged[i] = mass2[b++];
                   else
                       merged[i] = mass1[a++];
           }
           return merged;
       }
 
        static void Main(string[] args)
        {
             int[] arr = new int[100];
             
             Random rd = new Random();
             for(int i = 0; i < arr.Length; ++i) {
                arr[i] = rd.Next(1, 101);
             }
             System.Console.WriteLine("Массив до сортировки:");
             foreach (int x in arr)
             {
                System.Console.Write(x + " ");
             }
             
             arr = Merge_Sort(arr);
 
             System.Console.WriteLine("\n\nМассив после:");
             foreach (int x in arr)
             {
                System.Console.Write(x + " ");
             }
             System.Console.WriteLine();
        }
    }
}
