namespace Factorial
{
    class Hello
    {
        static int Function(int a)
        {
            int b = 1;
            for (int i = a; i > 0; i--)
            {
                b *= i;
            }
            return b;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the value");
            int value = Convert.ToInt32(Console.ReadLine());
            if (value >= 0)
            {
                int c = Function(value);
                Console.WriteLine($"The Factorial for {value} is {c}");
            }
            else
            {
                Console.WriteLine($"Enter Only Postive Value.Negative value cannot be accepted");
            }
        }
    }
}