using System;

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
                    Console.WriteLine("Invalid target value.");
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
