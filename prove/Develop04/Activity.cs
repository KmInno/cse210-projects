using System;
using System.Threading;

// this is the base class for the activities in the program
// includes methods for starting, running, and ending the activities for the mindfullness program
public abstract class Activity
{
    private int _duration; // Duration in seconds
    private string _name; // Name of the activity
    private string _description; // Description of the activity

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name}");
        Console.WriteLine(_description);
        Console.Write("Enter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        PauseWithAnimation(3);
        RunActivity();
        End();
    }

    protected abstract void RunActivity();

    protected void End()
    {
        Console.Clear();
        Console.WriteLine("Good job!");
        PauseWithAnimation(2);
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        PauseWithAnimation(3);
    }

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(2000); // Wait for 2 second
        }
        Console.WriteLine();
    }

    protected int Duration => _duration;

    protected void SetActivityInfo(string name, string description)
    {
        _name = name;
        _description = description;
    }
}
