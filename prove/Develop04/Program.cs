using System;

// this is the main program for the mindfullness program
// it provides the menue for the user to choose the activity they want to do
// it then loads the activity by refering the number the user inputes  following the switch statement buy the propts from that activity
// returns to the main menu after the activity is done
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Hello Develop04 World!");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Scripture Activity");
            Console.WriteLine("5. Quit");

            switch (Console.ReadLine())
            {
                case "1":
                    new BreathingActivity().Start();
                    break;
                case "2":
                    new ReflectionActivity().Start();
                    break;
                case "3":
                    new ListingActivity().Start();
                    break;
                case "4":
                    new ScriptureActivity().Start();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
