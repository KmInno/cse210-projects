using System;
// this class is for creating the goals from the user input
// i used deserialize method to create a goal object, split it into strings and extract the information from the strings
public static class GoalFactory
{
    public static Goal CreateGoal(string type, string name, int points, int targetCount = 0, int bonusPoints = 0)
    {
        if (type == "SimpleGoal")
        {
            return new SimpleGoal(name, points);
        }
        else if (type == "EternalGoal")
        {
            return new EternalGoal(name, points);
        }
        else if (type == "ChecklistGoal")
        {
            return new ChecklistGoal(name, points, targetCount, bonusPoints);
        }
        else
        {
            throw new ArgumentException("Invalid goal type");
        }
    }

    public static Goal Deserialize(string serializedGoal)
    {
        var parts = serializedGoal.Split(',');
        var type = parts[0];
        var name = parts[1];
        var points = int.Parse(parts[2]);

        if (type == "SimpleGoal")
        {
            var goal = new SimpleGoal(name, points);
            goal.SetIsComplete(bool.Parse(parts[3]));
            return goal;
        }
        else if (type == "EternalGoal")
        {
            var goal = new EternalGoal(name, points);
            goal.SetTimesRecorded(int.Parse(parts[3]));
            return goal;
        }
        else if (type == "ChecklistGoal")
        {
            var targetCount = int.Parse(parts[4]);
            var bonusPoints = int.Parse(parts[5]);
            var goal = new ChecklistGoal(name, points, targetCount, bonusPoints);
            goal.SetCurrentCount(int.Parse(parts[3]));
            return goal;
        }
        else
        {
            throw new ArgumentException("Invalid goal type");
        }
    }
}
