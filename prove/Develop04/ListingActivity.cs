using System;

// this is the Listening activity class for the mindfullness program
// it prompts the user for the good things they did throught the week and the user is supposed to type them in which are then counted afterwards

public class ListingActivity : Activity
{
    private static readonly string[] Prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        SetActivityInfo("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        PauseWithAnimation(3);
        Console.WriteLine("Start listing your items:");

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        int itemCount = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("- ");
            Console.ReadLine();
            itemCount++;
        }

        Console.WriteLine($"You listed {itemCount} items.");
    }
}
