using System;
using System.Collections.Generic;

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
        
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current score: {_score}");
    }

    public void ListGoalNames()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void ListGoalDetails()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        Goal selectedGoal = _goals[goalIndex];
        int pointsAwarded = selectedGoal.RecordEvent();
        _score += pointsAwarded;
    }

    public void SaveGoals(string filename)
    {
        
    }

    public void LoadGoals(string filename)
    {
        
    }
}
