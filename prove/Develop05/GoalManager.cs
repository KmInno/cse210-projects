using System;
using System.Collections.Generic;
using System.IO;
// this calls maintains the collection of the goals and the score of the user's total score
// provides a methos for the user to add new goal
// records new  entry for exitng goals
public class GoalManager
{
    private List<Goal> _goals;
    private int _totalScore;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _totalScore = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in _goals)
        {
            if (goal.GetName().Equals(goalName, StringComparison.OrdinalIgnoreCase))
            {
                goal.RecordEvent();
                _totalScore += goal.GetPoints();
                Console.WriteLine($"Congratulations! You have earned {goal.GetPoints()} points.");
                
                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
                {
                    _totalScore += checklistGoal.GetBonusPoints();
                }
                break;
            }
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {_totalScore}");
    }

    public void SaveGoals(string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
    }

    public void LoadGoals(string filePath)
    {
        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath);
            _goals = new List<Goal>();

            foreach (var line in lines)
            {
                _goals.Add(GoalFactory.Deserialize(line));
            }
        }
    }
}
