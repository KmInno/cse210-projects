using System;

// this is the breathing activity class for the mindfullness program
// it gives the user a few seconds to breath in and out slowly and afte the seconds it exits and returns to the main menu
// this activity also in herits some of the methods from the base class
public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        SetActivityInfo("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
    }

    protected override void RunActivity()
    {
        int halfDuration = Duration / 2;
        for (int i = 0; i < halfDuration; i++)
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(3);
            Console.WriteLine("Breathe out...");
            PauseWithAnimation(3);
        }
    }
}
