using System;

namespace task3
{
    /*
    3. Исполнитель Калькулятор преобразует целое число, записанное на экране. У исполнителя две команды, каждой команде присвоен номер:
    Прибавь 1 2.
    Умножь на 2 
    Первая команда увеличивает число на экране на 1,
    вторая увеличивает это число в 2 раза. 
    Сколько существует программ, которые число 3 преобразуют в число 20? 
    а) с использованием массива; 
    б) с использованием рекурсии.

    (c) Alexander Andreev
    */

    enum Operation
    {
        AddOne = 1,
        Mul2 = 2
    }

    class Program
    {
        static int AddOne(int num)
        {
            return num + 1;
        }

        static int Mul2( int num)
        {
            return num * 2;
        }

        static int[] ArrayCommands()
        {
            return new int[] {1, 1, 1, 1, 1, 1, 1, 2};
        }

        static int DoCommand(int start)
        {
            var arr = ArrayCommands();
            int result = start;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] == (int)Operation.AddOne)
                {
                    result = AddOne(result);
                }
                if(arr[i] == (int)Operation.Mul2)
                {
                    result = Mul2(result);
                }
            }

            return result;
        }

        // http://labs.org.ru/ege-22/#pr22_2
        static int CountCalc(int start, int end)
        {
            int min_one_operation = end;
            int[] numbers = new int[end];

            for(int i = end; i >= start; i-- )
            {
                int oper2 = Mul2(i);
                if(oper2 > end && i < min_one_operation){
                    min_one_operation = i;
                }
            }
            //System.Console.WriteLine(min_one_operation);
            
            numbers[min_one_operation] = 1;

            for(int i = min_one_operation - 1; i >= start; i--)
            {
                int sum_operations = 0;
                int addone = AddOne(i);
                                
                if(addone > min_one_operation)
                {
                    sum_operations += 1;
                }
                else
                {
                     sum_operations += numbers[addone];
                }
                
                int mul2 = Mul2(i);

                if(mul2 > min_one_operation)
                {
                    sum_operations += 1;
                }
                else
                {
                    sum_operations += numbers[mul2];
                }

                numbers[i] = sum_operations;                
            }

            return numbers[start];
        } // 18 вариантов

        static void Main(string[] args)
        {
            int start = 3;
            int end = 20;

            /*int result1 = DoCommand(start);
            if(result1 != end)
            {
                System.Console.WriteLine("Последовательность команд неверна!");
            }
            else
            {
                System.Console.WriteLine("Последовательность выполнена корректно!");
                var arr = ArrayCommands();
                System.Console.WriteLine("Количество команд {0} для получения числа {1} из {2}", arr.Length, end, start);
                System.Console.Write("[ ");
                foreach (var item in arr)
                {
                    System.Console.Write(item + ", ");
                }
                System.Console.WriteLine("]");
            }*/

////
             System.Console.WriteLine("Количество программ {0} для преобразования числа {1} в {2}", CountCalc(start, end), start, end);
        }
    }
}
