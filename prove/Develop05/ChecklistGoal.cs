using System;
// this class represents the checklist goals that the user can create and complete
// shows the number of goals that must be completed
// shows the number of goals that have been completed
// returns the bonus points that the user will get when they complete the goal
public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) 
        : base(name, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
        }
    }

    public bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    public void SetBonusPoints(int bonusPoints)
    {
        _bonusPoints = bonusPoints;
    }

    public override string GetStatus()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetName()} (Completed {_currentCount}/{_targetCount} times)";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal,{GetName()},{GetPoints()},{_currentCount},{_targetCount},{_bonusPoints}";
    }

    public int GetTargetCount()
    {
        return _targetCount;
    }

    public void SetTargetCount(int targetCount)
    {
        _targetCount = targetCount;
    }

    public int GetCurrentCount()
    {
        return _currentCount;
    }

    public void SetCurrentCount(int currentCount)
    {
        _currentCount = currentCount;
    }
}
