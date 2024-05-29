using System;

// this is the reflection part of the activity in the mindfullness program
// the user is given a questions and points to reflect on
// the program returns to the menu after the questions are and points all all listed to the user
// this program also in herits some of the methods from the base class
public class ReflectionActivity : Activity
{
    private static readonly string[] Prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        SetActivityInfo("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        PauseWithAnimation(3);

        int timePerQuestion = Duration / Questions.Length;
        foreach (var question in Questions)
        {
            Console.WriteLine(question);
            PauseWithAnimation(timePerQuestion);
        }
    }
}
