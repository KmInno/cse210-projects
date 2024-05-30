using System;
// this class is for the simple goals the user enters and are completed once
// has a boolen for showing goal is complete or not
// overrides the status of the goal to show it is completed
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, int points) : base(name, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override string GetStatus()
    {
        return _isComplete ? $"[X] {GetName()}" : $"[ ] {GetName()}";
    }

    public override string Serialize()
    {
        return $"SimpleGoal,{GetName()},{GetPoints()},{_isComplete}";
    }

    public bool GetIsComplete()
    {
        return _isComplete;
    }

    public void SetIsComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }
}
