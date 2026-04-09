
using System.Runtime.Intrinsics.Arm;

class Student
{
    private string name;
    private string email;

    private string phone_number;

    private int max_try = 0;

    private int thershold = 3;


    public delegate void LoginThershold();

    public event LoginThershold LimitReached;

    public Student(string name, string email, string phone_number)
    {
        this.name = name;
        this.email = email;
        this.phone_number = phone_number;
    }

    public void counter()
    {
        max_try++;
        Console.WriteLine($"Attempt to Login {max_try}");
        if (max_try > thershold)
        {
            Console.WriteLine($"Account Locked! After {thershold} try. Name - {name} Emaik - {email}");
        }
        if (max_try == thershold)
        {
            LimitReached?.Invoke();
        } 
        if (max_try == thershold * 2)
        {
            Console.WriteLine($"You can try now. It is refreshed");
            max_try=0;
        }  
    }

    public void Notification()
    {
        Console.WriteLine($"Hi!. {name} you have reached the limit to login retry after some time for the email {email}");
    }

    public void SMS()
    {
        Console.WriteLine($"Sending message to {phone_number}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Student s1 = new Student("Siva Kavindra", "sivakavindra@gmail.com", "9442378188");

        s1.LimitReached += s1.Notification;
        s1.LimitReached += s1.SMS;

        for (int i = 0; i < 10; i++)
        {
            s1.counter();
        }

    }
}