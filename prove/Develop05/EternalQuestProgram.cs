using System;
using System.Collections.Generic;
using System.IO;

// this class manages the collection of the goals and the score of the user's total score
// it has a list of goals that the user has created
// has a menu for the user to select what they want to do
// gives the user the option to save and load their goals
// gives feedback to the user when they complete a goal
public class EternalQuestProgram
{
    private List<Goal> _goals;
    private int _totalScore;

    public EternalQuestProgram()
    {
        _goals = new List<Goal>();
        _totalScore = 0;
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select the type of goal to create:");
        Console.WriteLine("1. Eternal goal");
        Console.WriteLine("2. Simple goal");
        Console.WriteLine("3. Checklist goal");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CreateEternalGoal();
                break;
            case "2":
                CreateSimpleGoal();
                break;
            case "3":
                CreateChecklistGoal();
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    private void CreateEternalGoal()
    {
        Console.WriteLine("Enter the name of the Eternal goal:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the points for the Eternal goal:");
        int points = int.Parse(Console.ReadLine());
        _goals.Add(new EternalGoal(name, points));
        Console.WriteLine("Eternal goal created successfully.");
    }

    private void CreateSimpleGoal()
    {
        Console.WriteLine("Enter the name of the Simple goal:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the points for the Simple goal:");
        int points = int.Parse(Console.ReadLine());
        _goals.Add(new SimpleGoal(name, points));
        Console.WriteLine("Simple goal created successfully.");
    }

    private void CreateChecklistGoal()
    {
        Console.WriteLine("Enter the name of the Checklist goal:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the points for the Checklist goal:");
        int points = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the target count for the Checklist goal:");
        int targetCount = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the bonus points for the Checklist goal:");
        int bonusPoints = int.Parse(Console.ReadLine());
        _goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
        Console.WriteLine("Checklist goal created successfully.");
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            Goal selectedGoal = _goals[choice];
            selectedGoal.RecordEvent();
            _totalScore += selectedGoal.GetPoints();
            int earnedPoints = selectedGoal.GetPoints();

            if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                _totalScore += checklistGoal.GetBonusPoints();
                earnedPoints += checklistGoal.GetBonusPoints();
            }

            Console.WriteLine($"Event recorded for goal: {selectedGoal.GetName()}");
            Console.WriteLine($"Congratulations! You have earned {earnedPoints} points.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void ShowGoals()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
    }

    public int GetScore() => _totalScore;

    public void Save(string filePath)
    {
        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            foreach (var goal in _goals)
            {
                string serializedGoal = goal.Serialize();
                outputFile.WriteLine(serializedGoal);
            }
        }
    }

    public void Load(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            _goals = new List<Goal>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(",");

                string goalType = parts[0];
                string name = parts[1];
                int points = int.Parse(parts[2]);

                if (goalType == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(parts[3]);
                    SimpleGoal simpleGoal = new SimpleGoal(name, points);
                    if (isComplete) simpleGoal.RecordEvent();
                    _goals.Add(simpleGoal);
                }
                else if (goalType == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(name, points));
                }
                else if (goalType == "ChecklistGoal")
                {
                    int targetCount = int.Parse(parts[3]);
                    int currentCount = int.Parse(parts[4]);
                    int bonusPoints = int.Parse(parts[5]);
                    ChecklistGoal checklistGoal = new ChecklistGoal(name, points, targetCount, bonusPoints);
                    checklistGoal.SetCurrentCount(currentCount);
                    _goals.Add(checklistGoal);
                }
            }
        }
    }

    public void ShowMenu()
    {
        string choice = string.Empty;

        while (choice != "4")
        {
            Console.WriteLine("1. Add a goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. Exit");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    Save("goals.txt");
                    Console.WriteLine("Exiting and saving goals.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // public static void Main(string[] args)
    // {
    //     EternalQuestProgram program = new EternalQuestProgram();
    //     program.Load("goals.txt");
    //     program.ShowMenu();
    // }
}
