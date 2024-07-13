using System;

public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }

    public abstract void RecordEvent();
    public virtual string GetDetailsString()
    {
        return $"{Name}: {Description} - Points: {Points}";
    }

    public abstract string ToFileString();
    public abstract void FromFileString(string data);
}

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal() { }

    public SimpleGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Simple goal '{Name}' completed. Points earned: {Points}");
    }

    public override string GetDetailsString()
    {
        return base.GetDetailsString() + $" - Completed: {_isComplete}";
    }

    public override string ToFileString()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
    }

    public override void FromFileString(string data)
    {
        var parts = data.Split('|');
        Name = parts[1];
        Description = parts[2];
        Points = int.Parse(parts[3]);
        _isComplete = bool.Parse(parts[4]);
    }
}

public class EternalGoal : Goal
{
    private int _totalPoints;

    public EternalGoal() { }

    public EternalGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        _totalPoints = 0;
    }

    public override void RecordEvent()
    {
        _totalPoints += Points;
        Console.WriteLine($"Eternal goal '{Name}' recorded. Total points: {_totalPoints}");
    }

    public override string GetDetailsString()
    {
        return base.GetDetailsString() + $" - Total Points: {_totalPoints}";
    }

    public override string ToFileString()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}|{_totalPoints}";
    }

    public override void FromFileString(string data)
    {
        var parts = data.Split('|');
        Name = parts[1];
        Description = parts[2];
        Points = int.Parse(parts[3]);
        _totalPoints = int.Parse(parts[4]);
    }
}

public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _target;

    public ChecklistGoal() { }

    public ChecklistGoal(string name, string description, int points, int target)
    {
        Name = name;
        Description = description;
        Points = points;
        _timesCompleted = 0;
        _target = target;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
        if (_timesCompleted == _target)
        {
            Console.WriteLine($"Checklist goal '{Name}' completed with a bonus! Total completions: {_timesCompleted}/{_target}. Points earned: {Points * _target + 500}");
        }
        else
        {
            Console.WriteLine($"Checklist goal '{Name}' recorded. Total completions: {_timesCompleted}/{_target}. Points earned: {Points}");
        }
    }

    public override string GetDetailsString()
    {
        return base.GetDetailsString() + $" - Completed: {_timesCompleted}/{_target}";
    }

    public override string ToFileString()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_timesCompleted}|{_target}";
    }

    public override void FromFileString(string data)
    {
        var parts = data.Split('|');
        Name = parts[1];
        Description = parts[2];
        Points = int.Parse(parts[3]);
        _timesCompleted = int.Parse(parts[4]);
        _target = int.Parse(parts[5]);
    }
}

public class NegativeGoal : Goal
{
    private int _badHabitCount;

    public NegativeGoal() { }

    public NegativeGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        _badHabitCount = 0;
    }

    public override void RecordEvent()
    {
        _badHabitCount++;
        Points--; // Lose a point for each bad habit recorded
        Console.WriteLine($"Negative goal '{Name}' recorded. Bad habits counted: {_badHabitCount}. Points lost: 1");
    }

    public override string GetDetailsString()
    {
        return base.GetDetailsString() + $" - Bad Habits: {_badHabitCount}";
    }

    public override string ToFileString()
    {
        return $"NegativeGoal|{Name}|{Description}|{Points}|{_badHabitCount}";
    }

    public override void FromFileString(string data)
    {
        var parts = data.Split('|');
        Name = parts[1];
        Description = parts[2];
        Points = int.Parse(parts[3]);
        _badHabitCount = int.Parse(parts[4]);
    }
}
