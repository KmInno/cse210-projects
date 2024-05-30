using System;
// this class provide a common interface and shared functionallity in all the goals
// stores the name of the goal
// stores the  points of the goal
public abstract class Goal
{
    private string _name;
    private int _points;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void SetPoints(int points)
    {
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();
}
