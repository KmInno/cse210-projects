using System;
using System.Collections.Generic;

// Base Activity class
class Activity
{
    private DateTime _date;
    private int _minutes;

    // Constructor
    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Virtual methods to be overridden in derived classes
    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    // Method to get summary (can be overridden in derived classes if needed)
    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} Activity ({_minutes} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }

    // Getters for the date and minutes
    protected DateTime Date => _date;
    protected int Minutes => _minutes;
}

// Running class derived from Activity
class Running : Activity
{
    private double _distance; // Distance in miles

    // Constructor
    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    // Override methods for Running
    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / _distance;
    }

    public override string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} Running ({Minutes} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

// Cycling class derived from Activity
class Cycling : Activity
{
    private double _speed; // Speed in mph

    // Constructor
    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    // Override methods for Cycling
    public override double GetDistance()
    {
        return (_speed * Minutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

    public override string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} Cycling ({Minutes} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

// Swimming class derived from Activity
class Swimming : Activity
{
    private int _numberOfLaps; // Number of laps

    // Constructor
    public Swimming(DateTime date, int minutes, int numberOfLaps)
        : base(date, minutes)
    {
        _numberOfLaps = numberOfLaps;
    }

    // Override methods for Swimming
    public override double GetDistance()
    {
        return (_numberOfLaps * 50 / 1000.0) * 0.62; // Convert meters to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} Swimming ({Minutes} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        // Create some activity objects
        Running running = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        Cycling cycling = new Cycling(new DateTime(2022, 11, 4), 45, 15.0);
        Swimming swimming = new Swimming(new DateTime(2022, 11, 5), 60, 40);

        // List of activities
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Display summaries of each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}
