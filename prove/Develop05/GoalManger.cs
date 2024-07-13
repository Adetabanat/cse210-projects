using System;
using System.Collections.Generic;
using System.IO;

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
