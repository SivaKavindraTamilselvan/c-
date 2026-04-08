using System;
using System.Collections.Generic;

class Student
{
    private static int Id = 1;

    public int id;
    public string name = "";
    public int age;
    public int[] grade = new int [5];

    public Student(string name,int age,int[] grade)
    {
        id = Id++;
        this.name = name;
        this.age = age;
        this.grade = grade;
    }
}
class Program
{
    static void Main(string[] args)
    {
        double THERSHOLD = 40;
        List<Student> students = new List<Student>();

        while (true)
        {
            Console.WriteLine("Enter Your Choice");
            Console.WriteLine("Enter 1 to add the student");
            Console.WriteLine("Enter 2 to display the students");
            Console.WriteLine("Enter 3 to display students whose age is above 20");
            Console.WriteLine("Enter 4 to display students whose grade is greater than THERSHOLD");
            Console.WriteLine("Enter 0 To leave the loop");

            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter the student name to insert");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the age of the students");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Grades");
                int[] grade = new int[5];
                for(int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Enter Mark for Subject : " + (i+1));
                    grade[i] = Convert.ToInt32(Console.ReadLine());
                }
                Student s = new Student(name,age,grade);
                students.Add(s);
                Console.WriteLine("Content added to the list");
            }
            else if(choice == 2)
            {
                foreach(Student s in students)
                {
                    Console.WriteLine("Student name " + s.name);
                    Console.WriteLine("Student Age " + s.age);
                    int a=1;
                    foreach(int g in s.grade)
                    {
                        Console.WriteLine($"Mark For Subject : {a++} is {g}");
                    }
                }
            }
            else if(choice == 3)
            {
                var filtered = students.Where(s=> s.age >20);
                Console.WriteLine("The student list whose age is 20");
                foreach(Student s in filtered)
                {
                    Console.WriteLine("Student Age " + s.age);
                    Console.WriteLine("Studnet Name " + s.name);
                }
            }
            else if (choice == 4)
            {
                Console.WriteLine("The student list whose grade is above Thershold in sorted order");
                var filtered = students.Where(s=> s.grade.Average() > THERSHOLD);
                filtered = filtered.OrderBy(s=>s.grade.Average());
                foreach(Student s in filtered)
                {
                    Console.WriteLine("Student age " + s.age);
                    Console.WriteLine("Student name " + s.name);
                    Console.WriteLine("Student Avg Grade "+s.grade.Average());
                }

            }
            else if (choice == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}