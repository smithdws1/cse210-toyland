using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int GetScore()
    {
        return _score;
    }

    private int GetPointsForLevel(int level)
    {
        if (level == 1)
        {
            return 50;
        }

        return (int)(GetPointsForLevel(level - 1) * 1.5);
    }

    public int GetLevel()
    {
        int level = 1;
        int pointsForNextLevel = GetPointsForLevel(level);

        while (_score >= pointsForNextLevel)
        {
            level++;
            pointsForNextLevel = GetPointsForLevel(level);
        }

        return level;
    }

    public void DisplayPlayerInfo()
    {
        int level = GetLevel();
        Console.WriteLine($"Current score: {_score}");
        Console.WriteLine($"Current level: {level}");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select goal type: 1. SimpleGoal 2. EternalGoal 3. ChecklistGoal");
        string goalType = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (goalType == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (goalType == "3")
        {
            Console.Write("Enter target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        int choice;
        while (true)
        {
            Console.Write("Enter the number of the goal: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out choice) && choice > 0 && choice <= _goals.Count)
            {
                choice--;
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid number corresponding to a goal.");
            }
        }

        _goals[choice].RecordEvent();
        _score += _goals[choice].GetPoints();
        Console.WriteLine($"Event recorded! Your new score is: {_score}");
        Console.WriteLine($"Current level: {GetLevel()}");
    }

    public void SaveGoals(string filePath)
    {
        try
        {
            Console.WriteLine($"Saving goals to: {filePath}");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving goals: {ex.Message}");
        }
    }

    public void LoadGoals(string filePath)
    {
        _goals.Clear();
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string type = parts[0];
                    if (type == "SimpleGoal")
                    {
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                    }
                    else if (type == "EternalGoal")
                    {
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    }
                    else if (type == "ChecklistGoal")
                    {
                        _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}