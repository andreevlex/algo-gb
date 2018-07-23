using System;
using System.Collections.Generic;

namespace task3
{
    /*
    3. ***Требуется обойти конём шахматную доску размером NxM,
    пройдя через все поля доски по одному разу.
    Здесь алгоритм решения такой же как и в задаче о 8 ферзях.
    Разница только в проверке положения коня.
    (c) Alxander Andreev
    */
    
    struct Point
    {
        public int x;
        public int y;
    }

    enum State
    {
        Vacant = 0,
        Close = 1
    }

    class Program
    {
        static  bool LegalCoord(int v, int bdSize)
        {
            if(v >= 0 && v < bdSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static Point[] LegalMoves(int x, int y, int bdSize)
        {
            int[,] moveoffset = new int[,] {{-1,-2},{-1,2},{-2,-1},{-2,1},
                   {1,-2},{1,2},{2,-1},{2,1}};
            
            Point[] result = new Point[0];
            int count = 0;

            for(int i = 0; i < moveoffset.GetLength(0); i++)
            {
                int newx = x + moveoffset[i, 0];
                int newy = y + moveoffset[i, 1];
                
                if(LegalCoord(newx, bdSize) && LegalCoord(newy, bdSize))
                {
                    count += 1;
                    Array.Resize(ref result, count);

                    var p = new Point();
                    p.x = newx;
                    p.y = newy;
                    
                    result[result.Length -1] = p;
                }
            }

            //System.Console.WriteLine("LegaMoveCount {0}", result.Length);
            return result;
        }

        static int N;
        static State[,] points;

        static void SetPoint(Point p, State value)
        {
            points[p.x, p.y] = value;
        }

        static State GetState(Point p)
        {
            return points[p.x, p.y];
        }

        static void PrintBoard()
        {
            for(int i = 0; i < N; i++)
            {
               System.Console.Write($"{i}");
                for(int j = 0; j < N; j ++)
                {
                    System.Console.Write("\t" + (int)points[i, j]);
                }
                System.Console.WriteLine();
            }
        }

        static void PrintPath(Stack<Point> path)
        {
            int[,] result = new int[N, N];
            var count = path.Count;

            foreach(var item in path)
            {
                result[item.x, item.y] =  count;
                count -= 1;
            }

            for(int i = 0; i < N; i++)
            {
               System.Console.Write($"{i}");
                for(int j = 0; j < N; j ++)
                {
                    System.Console.Write("\t" + (int)result[i, j]);
                }
                System.Console.WriteLine();
            }
        }

        static bool knightTour(int n, Stack<Point> path, Point v, int limit)
        {
            bool done = false;
            SetPoint(v, State.Close);
            path.Push(v);

            if(n < limit)
            {
                done = false;
                var legalmoves = LegalMoves(v.x, v.y, N);
                for(int i = 0; i < legalmoves.Length; i++)
                {
                    var cur_point = legalmoves[i];
                    if(GetState(cur_point) == State.Vacant)
                    {
                        done = knightTour(n + 1, path, cur_point, limit);
                    }
                    
                    if(done)
                    {
                        break;
                    }
                }

                if(!done)
                {
                    path.Pop();
                    SetPoint(v, State.Vacant);
                }
            }
            else
            {
                done = true;
            }

            return done;
        }

        static void InitGame(int bdSize)
        {
            N = bdSize;
            points = new State[N, N];
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j ++)
                {
                    points[i, j] = State.Vacant;
                }
            }
        }

        static void Main(string[] args)
        {  
            int bdSize = 5;

            InitGame(bdSize);
            var path = new Stack<Point>();
            var start = new Point();
            start.x = 4;
            start.y = 0;

            bool result = knightTour(0, path, start, (bdSize* bdSize) - 1 );   
            System.Console.WriteLine(result);  
            PrintBoard();   

            System.Console.WriteLine(path.Count);
            /*foreach(var item in path)
            {
                System.Console.WriteLine($"[{item.x}, {item.y}]");
            } */

            PrintPath(path);   
        }
    }
}
