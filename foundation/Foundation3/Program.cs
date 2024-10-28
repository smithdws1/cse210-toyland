using System;

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new Running(new DateTime(2024, 10, 28), 30, 3.5),
            new Cycling(new DateTime(2024, 10, 28), 60, 12.6),
            new Swimming(new DateTime(2024, 10, 28), 90, 50)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
