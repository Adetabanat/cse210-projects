using System;
using System.Collections.Generic;
using System.IO;

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

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void ListGoals()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void RecordEvent(string goalName)
    {
        var goal = _goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    public void SaveGoals(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.ToFileString());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals(string filePath)
    {
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                _goals.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    Goal goal = parts[0] switch
                    {
                        "SimpleGoal" => new SimpleGoal(),
                        "EternalGoal" => new EternalGoal(),
                        "ChecklistGoal" => new ChecklistGoal(),
                        "NegativeGoal" => new NegativeGoal(),
                        _ => throw new Exception("Unknown goal type")
                    };
                    goal.FromFileString(line);
                    _goals.Add(goal);
                }
            }
            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record an event");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(goalManager);
                    break;
                case "2":
                    goalManager.ListGoals();
                    break;
                case "3":
                    SaveGoals(goalManager);
                    break;
                case "4":
                    LoadGoals(goalManager);
                    break;
                case "5":
                    RecordGoalEvent(goalManager);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager goalManager)
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (for bad habits)");
        Console.Write("Choice: ");
        string goalType = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points associated with this goal: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points value.");
            return;
        }

        switch (goalType)
        {
            case "1":
                goalManager.AddGoal(new SimpleGoal(name, description, points));
                break;
            case "2":
                goalManager.AddGoal(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter the target number of completions: ");
                if (int.TryParse(Console.ReadLine(), out int target))
                {
                    goalManager.AddGoal(new ChecklistGoal(name, description, points, target));
                }
                else
                {
                    Console.WriteLine("Invalid number.");
                }
                break;
            case "4":
                goalManager.AddGoal(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void SaveGoals(GoalManager goalManager)
    {
        Console.Write("Enter the file name to save the goals: ");
        string fileName = Console.ReadLine();
        goalManager.SaveGoals(fileName);
    }

    static void LoadGoals(GoalManager goalManager)
    {
        Console.Write("Enter the file name to load the goals: ");
        string fileName = Console.ReadLine();
        goalManager.LoadGoals(fileName);
    }

    static void RecordGoalEvent(GoalManager goalManager)
    {
        Console.Write("Enter the name of the goal to record: ");
        string goalName = Console.ReadLine();
        goalManager.RecordEvent(goalName);
    }
}
