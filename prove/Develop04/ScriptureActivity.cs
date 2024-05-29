using System;

// this is an attempt to exceed the core requirements for the assigment of week04
// this is a simple scripture reflection activity part of the mindfullness program
// it gives the user a few options to reflect on their scripture study if with a yes/no reply from the user
public class ScriptureActivity : Activity
{
    public ScriptureActivity()
    {
        SetActivityInfo("Scripture Activity", "This activity will help you reflect on your scripture study and insights.");
    }

    protected override void RunActivity()
    {
        Console.WriteLine("Have you read your scriptures this week? (yes/no)");
        string response = Console.ReadLine()?.Trim().ToLower();

        Console.WriteLine("Take a few seconds to ponder...");
        PauseWithAnimation(3);

        Console.WriteLine("Did you find any insights during your reading? (yes/no)");
        response = Console.ReadLine()?.Trim().ToLower();

        Console.WriteLine("If you found any insights, remember to note them in your journal.");
        PauseWithAnimation(3);

        Console.WriteLine("Always listen to the words of the prophet.");
        PauseWithAnimation(3);
    }
}
