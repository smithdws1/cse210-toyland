using System;
//I added a different method to handle which Goal to record and event for.
//I added error handling for most of it
//I added a better Save Goals method; so i don't have to remember exact names.
//I added a way to level up and show my level when the Score is shown.
class Program
{
    private static GoalManager _goalManager = new GoalManager();
    private static string _filePath = "goals.txt";

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _goalManager.CreateGoal();
                    break;
                case "2":
                    _goalManager.ListGoalDetails();
                    break;
                case "3":
                    _goalManager.RecordEvent();
                    break;
                case "4":
                    _goalManager.DisplayPlayerInfo();
                    break;
                case "5":
                    _goalManager.SaveGoals(_filePath);
                    break;
                case "6":
                    _goalManager.LoadGoals(_filePath);
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}