using System;
using System.Collections.Generic;
using System.IO.Compression;
class Program
{
    static void Main(string[] args)
    {
        List<string> student_names = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter the Choice");
            Console.WriteLine("Enter 1 to Add");
            Console.WriteLine("Enter 2 to Delete");
            Console.WriteLine("Enter 3 to Display");
            Console.WriteLine("Enter 0 to break");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Enter the Student Name");
                string name = Console.ReadLine();
                name = name.Trim();
                name = name.ToUpper();

                if (student_names.Contains(name))
                {
                    Console.WriteLine("Student Name Aldready Added");
                }
                else
                {
                    student_names.Add(name);
                }

            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter the Student Name To Delete");
                string name = Console.ReadLine();
                name = name.Trim();
                name = name.ToUpper();
                if (student_names.Contains(name))
                {
                    student_names.IndexOf(name);
                    student_names.Remove(name);

                }
                else
                {
                    Console.WriteLine("Student Name Not Found");
                }

            }
            else if (choice == 3)
            {
                foreach (string i in student_names)
                {
                    Console.WriteLine(i);
                }
            }
            else if (choice == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Enter correct choice bw 0-3");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}