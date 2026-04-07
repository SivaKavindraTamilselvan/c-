using System;

class Person
{
    public string name = "";
    public int age;
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public Person(string name)
    {
        this.name = name;
    }

    public void PrintFunction()
    {
        Console.WriteLine("The name of the person " + name);
        if (age != 0)
        {
            Console.WriteLine("The age of the person is " + age);
        }
        
    }

    public void Introduce()
    {
        if (age != 0)
        {
            Console.WriteLine($"I would like to introduce {name} of age {age}");
        }
        else
        {
            Console.WriteLine($"I would like to introduce {name}.");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Person p1 = new Person("Siva Kavindra", 22);
        p1.PrintFunction();
        p1.Introduce();
        Console.WriteLine();

        Person p2 = new Person("Kavindra");
        p2.PrintFunction();
        p2.Introduce();


    }
}
