using System;
using System.Collections.Generic;

namespace task4
{
    /*
    4. *Создать библиотеку функций для работы с графами.
    (c) Alexander Andreev
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new[,] {
                {Int32.MaxValue, 3, Int32.MaxValue, 1, Int32.MaxValue, Int32.MaxValue},
                {3, Int32.MaxValue, 2, Int32.MaxValue, Int32.MaxValue, 3},
                {Int32.MaxValue, 2, Int32.MaxValue, 2, Int32.MaxValue, 1},
                {1, Int32.MaxValue, 2, Int32.MaxValue, 3, Int32.MaxValue},
                {Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, 3, Int32.MaxValue, 4},
                {Int32.MaxValue, 3, 1, Int32.MaxValue, 4, Int32.MaxValue}
            };

            var result = AlgoDijkstra(6, 0, matrix);
            PrintDist(result);

			var path = FindShortPathD(result, matrix, 5, 0);
			PrintPath(path);

			int[,] matrix2 = new[,] {
				{0, 3, 0, 1, 0, 0},
				{3, 0, 2, 0, 0, 3},
				{0, 2, 0, 2, 0, 1},
				{1, 0, 2, 0, 3, 0},
				{0, 0, 0, 3, 0, 4},
				{0, 3, 1, 0, 4, 0}
			};

			var result2 = WaveAlgo(matrix2, 0);
			PrintDist(result2);
			var path2 = FindShortPathW(result2, matrix2, 4, 0);
			PrintPath(path2);
		}

		static int[] AlgoDijkstra(int n, int start, int[,] matrix)
		{
			bool[] visited = new bool[n];
			int[] dist = new int[n];

			for (int i = 0; i < n; i++)
			{
				dist[i] = Int32.MaxValue;
			}
			dist[start] = 0;

			int index = 0;
			int u = 0;
			for (int i = 0; i < n; i++)
			{
				int min = Int32.MaxValue;
				for (int j = 0; j < n; j++)
				{
					if (!visited[j] && dist[j] < min)
					{
						min = dist[j];
						index = j;
					}

					visited[index] = true;
					u = index;
					for (int k = 0; k < n; k++)
					{
						if (!visited[k]
						&& matrix[u, k] != Int32.MaxValue
						&& dist[u] != Int32.MaxValue
						&& (dist[u] + matrix[u, k] < dist[k]))
						{
							dist[k] = dist[u] + matrix[u, k];
						}
					}
				}
			}

			return dist;
		}

		static void PrintDist(int[] mass)
		{
			System.Console.Write("[ ");
			foreach (var item in mass)
			{
				System.Console.Write(item + ", ");
			}
			System.Console.WriteLine(" ]");
		}

		static Stack<int> FindShortPathD(int[] dist, int[,] matrix, int start, int end)
		{
			var result = new Stack<int>();
			if (start >= dist.Length || start < 0 || end >= dist.Length || end < 0)
			{
				throw new Exception("Нет таких вершин!");
			}

			result.Push(start);
			int cur = start;
			while (cur != end)
			{
				for (int j = 0; j < dist.Length; j++)
				{
					if (dist[cur] - matrix[cur, j] == dist[j])
					{
						result.Push(j);
						cur = j;
					}
				}
			}

			return result;
		}

		static void PrintPath(Stack<int> path)
		{
			Console.Write("[ ");
			foreach (var item in path)
			{
				Console.Write(item + ", ");
			}
			Console.WriteLine(" ]");
		}

		static int[] WaveAlgo(int [,] matrix, int start)
		{
			int s = 1;
			int n = matrix.GetLength(0);
			Console.WriteLine(n);
			int[] peak = new int[n];
			peak[start] = 1;
			int wave = 1;

			while(s < n)
			{
				for(int k = 0; k < n; k++)
				{
					if(peak[k] == wave)
					{
						for(int j = k + 1; j < n; j++)
						{
							if(matrix[k,j] != 0 &&
									peak[j] == 0)
							{
								peak[j] = wave + 1;
								s++;
							}
						}
					}
				}
				wave += 1;
			}

			return peak;
		}

		static Stack<int> FindShortPathW(int[] dist, int[,] matrix, int start, int end)
		{
			var result = new Stack<int>();
			if (start >= dist.Length || start < 0 || end >= dist.Length || end < 0)
			{
				throw new Exception("Нет таких вершин!");
			}

			result.Push(start);
			int cur = start;
			while (cur != end)
			{
				for (int j = 0; j < dist.Length; j++)
				{
					if (matrix[cur, j] != 0 && dist[j] == (dist[cur] - 1) )
					{
						result.Push(j);
						cur = j;
					}
				}
			}

			return result;
		}
	}
}
