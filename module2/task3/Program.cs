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
        None = 0,
        AddOne = 1,
        Mul2 = 2
    }

    class Step
    {
        public int Value { get; set; }
        public Operation Operation { get; set; }
        public Step Pred { get; set; }

        public Step(int value, Operation operation, Step step)
        {
            Value = value;
            Operation = operation;
            Pred = step;
        }

        public override string ToString()
        {
            return String.Format("Value: {0}; Operation: {1}", this.Value, this.Operation);
        }
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

        static int start = 3;
        static int end = 20;
        static void Main(string[] args)
        {
            System.Console.WriteLine("Количество программ {0} для преобразования числа {1} в {2}", CountCalc(start, end), start, end);
            
            Varints1();
        }
    
        static void Varints1()
        {
            int count_variants = CountCalc(start, end);
            Step[] variants = new Step[count_variants];
            Step[] steps = new Step[count_variants * (end * 2)];
            int pos_variant = 0;
            FindVariant(start, ref steps, 0, null, ref variants, ref pos_variant);
            
            for(int i = 0; i < variants.Length; i++)
            {
                //System.Console.WriteLine("{0} - {1}", variants[i], i);
                var result = GetCommands(variants[i]);

                System.Console.Write("Вариант {0} количество команд {1}\t", i + 1, result.Length);
                System.Console.Write("{ ");
                foreach(var item in result)
                {
                    System.Console.Write(item + ", ");
                }
                System.Console.Write(" }");
                System.Console.WriteLine();
            }
        }

        static int[] GetCommands(Step variant)
        {
            int [] operations = new int[end * 2];
                
            var last_step = variant;
            int pos_operations = 0;
            operations[pos_operations] = (int)last_step.Operation;

            //System.Console.WriteLine(last_step);
            while(last_step.Pred != null)
            {
                pos_operations += 1;
                operations[pos_operations] = (int)last_step.Pred.Operation;

                //System.Console.WriteLine(last_step.Pred);
                last_step = last_step.Pred;
            }

            int length_data = 0;
            for(int i = operations.Length - 1; i >= 0; i--)
            {
                if(operations[i] != 0)
                {
                    length_data = i;
                    break;
                }
            }

            int[] result = new int[length_data + 1];
            
            int j = 0;
            for(int i = length_data; i >= 0; i--)
            {
                result[j] = operations[i];
                j += 1;
            }

            return result;
        }

        static void FindVariant(int value, ref Step[] steps, int pos, Step Pred, ref Step[] variants, ref int pos_variant)
        {
            //System.Console.WriteLine(value);
            if(value == end)
            {
                //System.Console.WriteLine(pos_variant);
                variants[pos_variant] = Pred;
                pos_variant += 1;

                return;
            }
            
            int oper1 = AddOne(value);
            int oper2 = Mul2(value);
            
            if(oper1 <= end)
            {
                steps[pos] = new Step(oper1, Operation.AddOne, Pred);
                pos += 1;
                FindVariant(oper1, ref steps, pos, steps[pos - 1], ref variants, ref pos_variant);
            }

            if(oper2 <= end)
            {
                steps[pos] = new Step(oper2, Operation.Mul2, Pred);
                pos += 1;
                FindVariant(oper2, ref steps, pos, steps[pos -1], ref variants, ref pos_variant);
            }

            return;
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

        static void PrintVariant(int start, int end)
        {
            int result1 = DoCommand(start);
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
            }
        }
    }
}
