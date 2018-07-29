using System;
using System.IO;

namespace task3
{
    /*
    3. *Разработать базу данных студентов из двух полей “Имя”, “Возраст”, “Табельный номер”,
    в которой использовать все знания, полученные на уроках.
    Считайте данные в двоичное дерево поиска.
    Реализуйте поиск по какому-нибудь полю базы данных (возраст, вес)
    (c) Alexander Andreev
    */

    enum Cmp
    {
        Less = -1,
        Equal = 0,
        Great = 1,
    }

    class Student
    {
        public int Id;
        public string Name;
        public int Age;
    }

    class Node
    {
        public Student data;
        public Node Left;
        public Node Right;
        public Node Parent;
    }

    class Program
    {
        static Node CreateNode(Node head, Student value)
        {
            Node result = new Node();
            result.Left = null;
            result.Right = null;
            result.Parent = head;
            result.data = value;

            return result;
        }

        static Cmp CompareStudents(Student left, Student right)
        {
            if(left.Id > right.Id)
            {
                return Cmp.Less;
            }
            if(left.Id < right.Id)
            {
                return Cmp.Great;
            }

            return Cmp.Equal;
        }

        static void Insert(ref Node head, Student value)
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
                var cmp = CompareStudents(tmp.data, value);
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

        static bool FindAge(Node head, int value, ref Node find_value)
        {
            if(head == null)
            {
                find_value = null;
                return false;
            }

            Node tmp = head;
            if(tmp.data.Age == value)
            {
                find_value = tmp;
                return true;
            }
                
            bool left_result = FindAge(tmp.Left, value, ref find_value);
            if(left_result)
            {
                return true;
            }

            bool right_result = FindAge(tmp.Right, value, ref find_value);
            if(right_result)
            {
                return true;
            }

            return false;
        }
                
        static void PrintTree(Node root)
        {
            if(root != null)
            {
                System.Console.Write(root.data.Id);
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

        static void Main(string[] args)
        {
            Node tree = null;
            string[] students = File.ReadAllLines("task3/database.txt");
            foreach (var item in students)
            {
                string[] line = item.Split(',');
                //System.Console.WriteLine(line[0]);
                var student = new Student();
                student.Id = Convert.ToInt32(line[0]);
                student.Name = line[1];
                student.Age = Convert.ToInt32(line[2]);

                Insert(ref tree, student);
            }

            PrintTree(tree);
            System.Console.WriteLine();

            int age = 16;
            Node find_value = null;
            bool result = FindAge(tree, age, ref find_value);
            if(result)
            {
                System.Console.WriteLine("Найден студент: Id: {0}; Name: {1}; Age: {2}", 
                find_value.data.Id, find_value.data.Name, find_value.data.Age);
            }
            else
            {
                System.Console.WriteLine("Not Found!");
            }
            //Console.WriteLine("Hello World!");
        }
    }
}
