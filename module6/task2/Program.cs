using System;
using System.IO;

namespace task2
{
/*
2. Переписать программу, реализующее двоичное дерево поиска.

а) Добавить в него обход дерева различными способами;
б) Реализовать поиск в двоичном дереве поиска;
в) *Добавить в программу обработку командной строки с помощью которой можно указывать
из какого файла считывать данные, каким образом обходить дерево.
(c) Alexander Andreev
*/
    enum Cmp
    {
        Less = -1,
        Equal = 0,
        Great = 1,
    }

    class Node
    {
        public int data;
        public Node Left;
        public Node Right;
        public Node Parent;
    }

    class Program
    {
        static Node CreateNode(Node head, int value)
        {
            Node result = new Node();
            result.Left = null;
            result.Right = null;
            result.Parent = head;
            result.data = value;

            return result;
        }

        static Cmp Compare(int left, int right)
        {
            if(left > right)
            {
                return Cmp.Less;
            }
            if(left < right)
            {
                return Cmp.Great;
            }

            return Cmp.Equal;
        }

        static void Insert(ref Node head, int value)
        {
            Node tmp = null;

            if(head == null)
            {
                head = CreateNode(null, value);
                return;
            }

            tmp = head;
            while (tmp != null)
            {
                var cmp = Compare(tmp.data, value);
                if(cmp == Cmp.Great)
                {
                    if(tmp.Right != null)
                    {
                        tmp = tmp.Right;
                        continue;
                    }
                    else
                    {
                        tmp.Right = CreateNode(tmp, value);
                        return;
                    }
                } else if(cmp == Cmp.Less)
                {
                    if(tmp.Left != null)
                    {
                        tmp = tmp.Left;
                        continue;
                    }
                    else
                    {
                        tmp.Left = CreateNode(tmp, value);
                        return;
                    }
                }
                else
                {
                    throw new Exception("Дерево построено неправильно");
                }               
            }
        }

        static void PrintTree(Node root)
        {
            if(root != null)
            {
                System.Console.Write(root.data);
                if(root.Left != null || root.Right != null)
                {
                    System.Console.Write("(");

                    if(root.Left != null)
                    {
                        PrintTree(root.Left);
                    }
                    else
                    {
                        System.Console.Write("NULL");
                    }
                    
                    System.Console.Write(",");

                    if(root.Right != null)
                    {
                        PrintTree(root.Right);
                    }
                    else
                    {
                        System.Console.Write("NULL");
                    }

                    System.Console.Write(")");
                }
            }
        }

        static void preOrderTravers(Node root)
        {
            if(root != null)
            {
                System.Console.WriteLine(root.data);
                
                preOrderTravers(root.Left);    
                preOrderTravers(root.Right);
            }
        }

        static void inOrderTravers(Node root)
        {
            if(root != null)
            {
                inOrderTravers(root.Left);
                System.Console.WriteLine(root.data);
                inOrderTravers(root.Right);
            }
        }

        static void postOrderTravers(Node root)
        {
            if(root != null)
            {
                postOrderTravers(root.Left);
                postOrderTravers(root.Right);
                System.Console.WriteLine(root.data);
            }
        }

        static bool Find(Node head, int value, ref Node find_value)
        {
            if(head == null)
            {
                find_value = null;
                return false;
            }

            Node tmp = head;
            if(tmp.data == value)
            {
                find_value = tmp;
                return true;
            }
                
            bool left_result = Find(tmp.Left, value, ref find_value);
            if(left_result)
            {
                return true;
            }
            
            bool right_result = Find(tmp.Right, value, ref find_value);
            if(right_result)
            {
                return true;
            }
            
            return false;
        }

        static void Main(string[] args)
        {
            Node tree = null;
            if(args.Length < 2)
            {
                Environment.Exit(-1);
            }

            string method = args[0];
            string path = args[1];

            string[] data = File.ReadAllLines(path);
            foreach (var item in data)
            {
                var value = Convert.ToInt32(item);
                
                Insert(ref tree, value);
            }

            int value1 = 13;
            Node find_value = null;
            var result = Find(tree, value1, ref find_value);
            if(result)
            {
                System.Console.WriteLine("Найден элемент Value: {0}",find_value.data);
            }
            else
            {
                System.Console.WriteLine("Элемент {0} Not Found!", value1);
            }

            int value2 = 12;
            Node find_value2 = null;
            var result2 = Find(tree, value2, ref find_value2);
            if(result2)
            {
                System.Console.WriteLine("Найден элемент Value: {0}",find_value2.data);
            }
            else
            {
                System.Console.WriteLine("Элемент {0} Not Found!", value2);
            }

            PrintTree(tree);
            System.Console.WriteLine();

            if(method == "pre-order")
            {
                preOrderTravers(tree);
            }
            else if(method == "in-order")
            {
                inOrderTravers(tree);
            }
            else if(method == "post-order")
            {
                postOrderTravers(tree);
            }
            else
            {
                System.Console.WriteLine("Method not found");
            }
        }
    }
}
