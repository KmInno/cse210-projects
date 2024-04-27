using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        
        // int x = 5;
        // int y = 6;

        // if (x > y)
        // {
        //     Console.WriteLine("greater");
        // }
        // else if (x > y)
        // {
        //     Console.WriteLine("less");
        // }
        // else
        // {
        //     Console.WriteLine("Equal");
        // }
        
        Console.Write("Enter your percentage: ");
        string grade = Console.ReadLine();

        int number = int.Parse(grade);

        if ( number >= 90 )
        {
            Console.WriteLine("your grade is A");
        }
        else if (number >= 80)
        {
            Console.WriteLine("your grade is B");
        }
        else if (number >= 70)
        {
            Console.WriteLine("your grade is C");
        }
        else if (number >= 60)
        {
            Console.WriteLine("your grade is D");
        }
        else
        {
            Console.WriteLine("your grade is F");
        }

    }
}