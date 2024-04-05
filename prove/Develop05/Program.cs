using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
abstract class Goal
{
    protected string name;
    protected int value;

    public Goal(string name, int value)
    {
        this.name = name;
        this.value = value;
    }

    public abstract void RecordEvent();
    public abstract string GetDetailsString();
}

[Serializable]
class SimpleGoal : Goal
{
    private bool isComplete;

    public SimpleGoal(string name, int value) : base(name, value)
    {
        isComplete = false;
    }

    public override void RecordEvent()
    {
        isComplete = true;
        Console.WriteLine($"Goal '{name}' completed! You gained {value} points.");
    }

    public override string GetDetailsString()
    {
        return $"{name} - {(isComplete ? "Completed" : "Not Completed")}";
    }
}

[Serializable]
class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Eternal Goal '{name}' recorded! You gained {value} points.");
    }

    public override string GetDetailsString()
    {
        return $"{name} (Eternal)";
    }
}

[Serializable]
class ChecklistGoal : Goal
{
    private int completedTimes;
    private int targetTimes;
    private int bonusPoints;

    public ChecklistGoal(string name, int value, int targetTimes, int bonusPoints) : base(name, value)
    {
        completedTimes = 0;
        this.targetTimes = targetTimes;
        this.bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        completedTimes++;
        Console.WriteLine($"Checklist Goal '{name}' recorded! You gained {value} points.");

        if (completedTimes == targetTimes)
        {
            Console.WriteLine($"Congratulations! You achieved the target {targetTimes} times and earned a bonus of {bonusPoints} points.");
        }
    }

    public override string GetDetailsString()
    {
        return $"{name} - Completed {completedTimes}/{targetTimes} times";
    }
}

class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int totalScore = 0;

    static void Main(string[] args)
    {
        LoadGoals();

        while (true)
        {
            Console.WriteLine("\nEternal Quest - Goal Tracker");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. View Score");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    DisplayGoals();
                    break;
                case "2":
                    CreateNewGoal();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    ViewScore();
                    break;
                case "5":
                    SaveGoals();
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    break;
            }
        }
    }

    static void DisplayGoals()
    {
        Console.WriteLine("\nGoals List:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    static void CreateNewGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal type (1. Simple, 2. Eternal, 3. Checklist): ");
        string typeInput = Console.ReadLine();

        int type = int.Parse(typeInput);

        Console.Write("Enter goal value: ");
        int value = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                goals.Add(new SimpleGoal(name, value));
                break;
            case 2:
                goals.Add(new EternalGoal(name, value));
                break;
            case 3:
                Console.Write("Enter target times: ");
                int targetTimes = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, value, targetTimes, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type!");
                break;
        }

        Console.WriteLine("New goal created successfully!");
    }

    static void RecordEvent()
    {
        Console.WriteLine("\nSelect a goal to record event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }

        Console.Write("Enter goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordEvent();
            totalScore += goals[index].value;
        }
        else
        {
            Console.WriteLine("Invalid goal number!");
        }
    }

    static void ViewScore()
    {
        Console.WriteLine($"\nTotal Score: {totalScore}");
    }

    static void SaveGoals()
    {
        using (FileStream fs = new FileStream("goals.dat", FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, goals);
        }
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.dat"))
        {
            using (FileStream fs = new FileStream("goals.dat", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                goals = (List<Goal>)formatter.Deserialize(fs);
            }
        }
    }
}