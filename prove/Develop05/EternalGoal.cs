using System;
// this for eternal class thay can never be completed by the user but can show how many times the user had done that goal
// intializes the name and points of the goal
// always shows the goal as incomplete
// 
public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, int points) : base(name, points)
    {
        _timesRecorded = 0;
    }

    public override void RecordEvent()
    {
        _timesRecorded++;
    }

    public override string GetStatus()
    {
        return $"[ ] {GetName()} (Recorded {_timesRecorded} times)";
    }

    public override string Serialize()
    {
        return $"EternalGoal,{GetName()},{GetPoints()},{_timesRecorded}";
    }

    public int GetTimesRecorded()
    {
        return _timesRecorded;
    }

    public void SetTimesRecorded(int timesRecorded)
    {
        _timesRecorded = timesRecorded;
    }
}
