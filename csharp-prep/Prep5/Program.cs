using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();

        PromptUserNumber();

        PromptSquareNumber(userName);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program");
    }

    static string PromptUserName()
    {
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        Console.WriteLine("Your Username is " + userName);
        return userName;
    }

    static void PromptUserNumber()
    {
        Console.Write("Enter a favorite number: ");
        int userNumber = int.Parse(Console.ReadLine()); // Read input as integer
        Console.WriteLine($"Your number is {userNumber}");
    }

    static void PromptSquareNumber(string userName)
    {
        Console.Write("Enter a number: ");
        int userNumber = int.Parse(Console.ReadLine()); // Read input as integer
        int squareNumber = userNumber * userNumber;
        Console.WriteLine($"Brother {userName}, the square of your number is {squareNumber}");
    }
}
