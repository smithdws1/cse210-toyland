using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input = -1;

        Console.WriteLine("Enter a series of numbers, type 0 when finished.");

        while (input !=0)
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0)
            {
                numbers.Add(input);
            }
        }
        int sum = 0;
        foreach(int number in numbers)
        {
            sum += number;
            
        }
        Console.WriteLine("The Sum is: " + sum);
        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;
        Console.WriteLine("The Average is: " + average);
        int? smallestPositive = null;
        foreach (int number in numbers)
        {
            if (number > 0 && (smallestPositive == null || number < smallestPositive))
            {
                smallestPositive = number;
            }
        }
        Console.WriteLine("The smallest positive number is: " + (smallestPositive.HasValue ? smallestPositive.Value.ToString() : "None"));

        numbers.Sort();
        Console.WriteLine("Here is the sorted list:");
        foreach (int number in numbers) 
        {
            Console.WriteLine(number);
        }
    }

}