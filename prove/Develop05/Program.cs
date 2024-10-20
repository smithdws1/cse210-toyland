using System;
using System.Collections.Generic;
//For a stretch I made sure no random prompts/questions are selected until they had all been used at least once in that session.
//I also added more questions to each Activity
//And, I added a countdown to the Breathing Activity

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public virtual void Run()
    {

    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name}...");
        Console.WriteLine(_description);
        Console.Write("Enter duration (seconds): ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Well done! You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(1000);
        }
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through a breathing exercise: breathing in, holding, and exhaling slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        for (int i = 0; i < _duration; i += 22)
        {
            Console.WriteLine("Breathe in for 4 seconds...");
            ShowCountDownWithTimer(4);

            Console.WriteLine("Hold for 8 seconds...");
            ShowCountDownWithTimer(8);

            Console.WriteLine("Exhale for 10 seconds...");
            ShowCountDownWithTimer(10);
        }

        DisplayEndingMessage();
    }

    private void ShowCountDownWithTimer(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(1000);
        }
    }
}



public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _usedPrompts = new List<string>();
    private int _count;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are things you are grateful for today?",
        "What recent successes have you experienced?",
        "Who are people who inspire you?",
        "What are skills that you are proud of?",
        "What are things that make you happy?",
        "Who are people who have helped you in life?",
        "What are your favorite memories from the past year?",
        "What are some goals you've achieved recently?",
        "Who are people that you trust the most?",
        "What challenges have you overcome?",
        "What places make you feel peaceful or calm?",
        "What qualities do you value most in your friends?",
        "What activities make you feel most alive?",
        "Who are people you can always count on?",
        "What do you love most about yourself?",
        "What accomplishments are you most proud of?",
        "What are things you look forward to in the future?",
        "Who are people you've shared meaningful experiences with?",
        "What are lessons you have learned from difficult times?",
        "What are some things that you can do to help others?"
    };
    }


    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);

        _count = 0;
        Console.WriteLine("Start listing...");
        ShowSpinner(5); 

        DateTime start = DateTime.Now;
        while ((DateTime.Now - start).TotalSeconds < _duration)
        {
            Console.Write("Item: ");
            string item = Console.ReadLine();
            _count++;
        }

        Console.WriteLine($"You listed {_count} items.");
        DisplayEndingMessage();
    }


    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts.Clear();
        }

        List<string> remainingPrompts = new List<string>();
        foreach (string prompt in _prompts)
        {
            if (!_usedPrompts.Contains(prompt))
            {
                remainingPrompts.Add(prompt);
            }
        }

        Random random = new Random();
        string selectedPrompt = remainingPrompts[random.Next(remainingPrompts.Count)];
        _usedPrompts.Add(selectedPrompt);

        return selectedPrompt;
    }
}

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedPrompts = new List<string>();
    private List<string> _usedQuestions = new List<string>();

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);

        DateTime start = DateTime.Now;
        while ((DateTime.Now - start).TotalSeconds < _duration)
        {
            string question = GetRandomQuestion();
            Console.WriteLine(question);
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }


    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts.Clear();
        }

        List<string> remainingPrompts = new List<string>();
        foreach (string prompt in _prompts)
        {
            if (!_usedPrompts.Contains(prompt))
            {
                remainingPrompts.Add(prompt);
            }
        }

        Random random = new Random();
        string selectedPrompt = remainingPrompts[random.Next(remainingPrompts.Count)];
        _usedPrompts.Add(selectedPrompt);

        return selectedPrompt;
    }

    private string GetRandomQuestion()
    {
        if (_usedQuestions.Count == _questions.Count)
        {
            _usedQuestions.Clear();
        }

        List<string> remainingQuestions = new List<string>();
        foreach (string question in _questions)
        {
            if (!_usedQuestions.Contains(question))
            {
                remainingQuestions.Add(question);
            }
        }

        Random random = new Random();
        string selectedQuestion = remainingQuestions[random.Next(remainingQuestions.Count)];
        _usedQuestions.Add(selectedQuestion);

        return selectedQuestion;
    }

    private void DisplayQuestions()
    {
        ShowSpinner(3);
    }
}

public class Program
{
    private static List<Activity> _activities;

    public static void Main()
    {
        _activities = new List<Activity>
        {
            new BreathingActivity(),
            new ListingActivity(),
            new ReflectingActivity()
        };

        while (true)
        {
            DisplayMenu();

            string choice = Console.ReadLine();

            if (choice == "4")
            {
                Console.WriteLine("So long; farewell; Auf Wiedersehen, goodbyyye!");
                break;
            }

            int activityIndex = int.Parse(choice) - 1;
            if (activityIndex >= 0 && activityIndex < _activities.Count)
            {
                _activities[activityIndex].Run();
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Listing Activity");
        Console.WriteLine("3. Reflecting Activity");
        Console.WriteLine("4. Quit");
    }
}
