using System;
// this is the main class of the Eternal Quest program
// create a continiuous loop for the user to choose what they want to do
// respoisble for goal management


class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddGoal(manager);
                    break;
                case "2":
                    RecordEvent(manager);
                    break;
                case "3":
                    manager.DisplayGoals();
                    break;
                case "4":
                    manager.DisplayScore();
                    break;
                case "5":
                    SaveGoals(manager);
                    break;
                case "6":
                    LoadGoals(manager);
                    break;
                case "7":
                    return;
            }
        }
    }

    static void AddGoal(GoalManager manager)
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Eternal Goal");
        Console.WriteLine("2. Simple Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose an option: ");
        string typeOption = Console.ReadLine();
        string type = "";

        switch (typeOption)
        {
            case "1":
                type = "EternalGoal";
                break;
            case "2":
                type = "SimpleGoal";
                break;
            case "3":
                type = "ChecklistGoal";
                break;
            default:
                Console.WriteLine("Invalid option.");
                return;
        }

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "SimpleGoal")
        {
            manager.AddGoal(GoalFactory.CreateGoal(type, name, points));
        }
        else if (type == "EternalGoal")
        {
            manager.AddGoal(GoalFactory.CreateGoal(type, name, points));
        }
        else if (type == "ChecklistGoal")
        {
            Console.Write("Enter target count: ");
            int targetCount = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonusPoints = int.Parse(Console.ReadLine());
            manager.AddGoal(GoalFactory.CreateGoal(type, name, points, targetCount, bonusPoints));
        }
    }

    static void RecordEvent(GoalManager manager)
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        manager.RecordEvent(name);

        // this is an attempt to excced the requirements of the program
        // int totalScore = manager.GetTotalScore();
        // if (totalScore >= 100 && manager.GetPreviousTotalScore() < 100)
        // {
        //     Console.WriteLine("Congratulations! You have leveled up!");
        // }

    }


    static void SaveGoals(GoalManager manager)
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        manager.SaveGoals(filename);
    }

    static void LoadGoals(GoalManager manager)
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        manager.LoadGoals(filename);
    }
}
