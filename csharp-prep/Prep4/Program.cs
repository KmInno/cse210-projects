using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep4 World!");
        List<int> numbers = new List<int>();
        Console.Write("Enter a list of number, type 0 when finished.");
        int figure;

        do
        {
            figure = int.Parse(Console.ReadLine());
            if (figure != 0)
            {
                numbers.Add(figure);
            }
        }
        while (figure != 0);

        Console.WriteLine("numbers registered");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);

        }
        int sum = 0;
        foreach(int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine("Sum of numbers: " + sum);

        int numberCount = numbers.Count;
        float Average = (float)sum / numberCount;

        Console.WriteLine("The average is: " + Average);

    }
}