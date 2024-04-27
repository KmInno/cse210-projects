using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep1 World!");
        // Console.WriteLine("hey this is your first c# code");

        // Console.Write("what is your name?");
        // string name = Console.ReadLine();
        // Console.WriteLine($"your name is {name}");

        // int x = 5;
        // int y = 10;

        // if (x < y)
        // {
        //     Console.WriteLine("")
        // }

        Console.WriteLine("What is your first name? ");
        string first_name = Console.ReadLine();
        Console.WriteLine("What is your last name?");
        string last_name = Console.ReadLine();

        Console.WriteLine($"Your name is {last_name}, {first_name} {last_name}");

    }
}