using System;

class Program
{
    static void Main(string[] args)
    {
        Random magicalNumber= new Random();
        int number = magicalNumber.Next(1, 11);
        int guess = 0;

        Console.WriteLine(" what is the maigical number between 1-11? ");

        while (guess != number)
        {
            Console.Write("number: ");
            guess = int.Parse(Console.ReadLine());

            if (number > guess)
            {
                Console.WriteLine("it's Higer");
            }
            else if (number < guess)
            {
                Console.WriteLine("it's Lower");
            }
            else
            {
                Console.WriteLine("Hoho! you guessed it");
            }
        }

    }
}