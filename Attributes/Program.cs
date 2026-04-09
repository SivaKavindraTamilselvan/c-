using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute
{
}


public class Circle
{
    [Runnable]
    public void Area()
    {
        Console.WriteLine("Enter the radius for circle");
        double radius = Convert.ToDouble(Console.ReadLine());
        double area = Math.PI * radius * radius;

        Console.WriteLine("Circle Area: " + area);
    }
}

public class Rectangle
{
    [Runnable]
    public void Area()
    {
        Console.WriteLine("Enter the length for Rectangle");
        double length = Convert.ToDouble(Console.ReadLine());
        
        Console.WriteLine("Enter the width for Rectangle");
        double width = Convert.ToDouble(Console.ReadLine());

        double area = length * width;

        Console.WriteLine("Rectangle Area: " + area);
    }
}

public class Triangle
{
    [Runnable]
    public void Area()
    {
        Console.WriteLine("Enter the breadth for Triangle");
        double breadth = Convert.ToDouble(Console.ReadLine());
        
        Console.WriteLine("Enter the height for Triangle");
        double height = Convert.ToDouble(Console.ReadLine());


        double area = 0.5 * breadth * height;

        Console.WriteLine("Triangle Area: " + area);
    }
}



public class Runner
{
    public static void Execute()
    {
        var assembly = Assembly.GetExecutingAssembly();

        foreach (var type in assembly.GetTypes())
        {
            foreach (var method in type.GetMethods())
            {
                if (method.GetCustomAttribute<RunnableAttribute>() != null)
                {
                    var obj = Activator.CreateInstance(type);
                    method.Invoke(obj, null);
                }
            }
        }
    }
}



class Program
{
    static void Main()
    {
        Runner.Execute();
    }
}