using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Keep up the great work on your Eternal Quest!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        // Exceeding Requirements: Dynamic Title / Rank Leveling System based on score
        string rank = GetPlayerRank(_score);
        Console.WriteLine($"\n========================================");
        Console.WriteLine($" You have {_score} points. | Rank: {rank}");
        Console.WriteLine($"========================================");
    }

    private string GetPlayerRank(int score)
    {
        if (score < 500) return "Novice Seeker 🛡️";
        if (score < 1500) return "Apprentice Adventurer 🗡️";
        if (score < 3000) return "Dedicated Paladin ⚔️";
        if (score < 5000) return "Master of Discipline 🔮";
        return "Legendary Eternal Knight ⭐";
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetName()}");
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (Bad Habit Penalty)");
        Console.Write("Which type of goal would you like to create? ");

        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                Console.WriteLine("⚠️ Negative goal created. Recording this will deduct points!");
                break;
            default:
                Console.WriteLine("Invalid goal type selected.");
                break;
        }
        Console.WriteLine("Goal created successfully!");
    }

    private void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];

            // Handle Negative Goals differently (deduct points)
            if (goal is NegativeGoal)
            {
                _score -= goal.GetPoints();
                Console.WriteLine($"\n⚠️ Bad habit recorded. You lost {goal.GetPoints()} points.");
            }
            else
            {
                int earnedPoints = goal.GetPoints();
                goal.RecordEvent();

                // Check for checklist bonus
                if (goal is ChecklistGoal checklistGoal)
                {
                    if (checklistGoal.IsComplete() && checklistGoal.GetAmountCompleted() == checklistGoal.GetTarget())
                    {
                        earnedPoints += checklistGoal.GetBonus();
                        Console.WriteLine($"🎉 Bonus achieved! Added extra {checklistGoal.GetBonus()} points!");
                    }
                }

                _score += earnedPoints;
                Console.WriteLine($"\nCongratulations! You have earned {earnedPoints} points!");
            }

            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(":");
                string goalType = parts[0];
                string details = parts[1];

                string[] data = details.Split(",");

                if (goalType == "SimpleGoal")
                {
                    string name = data[0];
                    string description = data[1];
                    int points = int.Parse(data[2]);
                    bool isComplete = bool.Parse(data[3]);

                    SimpleGoal goal = new SimpleGoal(name, description, points, isComplete);
                    _goals.Add(goal);
                }
                else if (goalType == "EternalGoal")
                {
                    string name = data[0];
                    string description = data[1];
                    int points = int.Parse(data[2]);

                    EternalGoal goal = new EternalGoal(name, description, points);
                    _goals.Add(goal);
                }
                else if (goalType == "ChecklistGoal")
                {
                    string name = data[0];
                    string description = data[1];
                    int points = int.Parse(data[2]);
                    int bonus = int.Parse(data[3]);
                    int target = int.Parse(data[4]);
                    int amountCompleted = int.Parse(data[5]);

                    ChecklistGoal goal = new ChecklistGoal(name, description, points, bonus, target, amountCompleted);
                    _goals.Add(goal);
                }
                else if (goalType == "NegativeGoal")
                {
                    string name = data[0];
                    string description = data[1];
                    int points = int.Parse(data[2]);

                    NegativeGoal goal = new NegativeGoal(name, description, points);
                    _goals.Add(goal);
                }
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}