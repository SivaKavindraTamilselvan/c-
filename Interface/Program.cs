using System;
using System.Collections.Generic;


public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public string PhoneNumber { get; set; }

    public string Department { get; set; }

    public virtual void Display()
    {
        Console.WriteLine(Name);
        Console.WriteLine(Age);
        Console.WriteLine(PhoneNumber);
        Console.WriteLine(Department);
    }

}

public class Student : Person
{
    public string rollNumber { get; set; }

    public override void Display()
    {
        base.Display();
        Console.WriteLine(rollNumber);
    }
}
public class Teacher : Person
{
    public string Subject { get; set; }

    public override void Display()
    {
        base.Display();
        Console.WriteLine(Subject);
    }
}


public interface College<T>
{
    void Add(List<T> list, T item);
    void Update(List<T> list, T old_item, T item);
    void Delete(List<T> list, T item);
    void Display(List<T> list);
}

public class CollegeService<T> : College<T> where T : Person
{
    public void Add(List<T> list, T item)
    {
        Console.WriteLine("Student Details Added");
        list.Add(item);
        Console.WriteLine();
    }

    public void Update(List<T> list, T old_item, T item)
    {
        Console.WriteLine("Student Updation Happening");
        int index = list.IndexOf(old_item);

        if (index != -1)
        {
            list[index] = item;
        }
        Console.WriteLine();
    }

    public void Delete(List<T> list, T item)
    {
        Console.WriteLine("Deletion Happening");
        list.Remove(item);
        Console.WriteLine();
    }

    public void Display(List<T> list)
    {
        foreach (var item in list)
        {
            item.Display();
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        List<Teacher> teachers = new List<Teacher>();

        CollegeService<Student> studentService = new CollegeService<Student>();
        CollegeService<Teacher> teacherService = new CollegeService<Teacher>();

        Student s1 = new Student { Name = "Siva Kavindra", Age = 21, Department = "CSD", PhoneNumber = "9442378188", rollNumber = "22CDR096" };

        studentService.Add(students, s1);

        Teacher t1 = new Teacher { Name = "Kavindra", Age = 41, Department = "CSD", Subject = "Web", PhoneNumber = "9489698188" };

        teacherService.Add(teachers, t1);

        Student s2 = new Student { Name = "Siva", Age = 21, Department = "CSD", PhoneNumber = "9442378188", rollNumber = "22CDR096" };

        studentService.Add(students, s2);

        studentService.Update(students, s1, s2);

        studentService.Display(students);

        studentService.Delete(students, s2);

        studentService.Display(students);
    }
}