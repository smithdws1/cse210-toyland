using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            int magicNumber = random.Next(1, 101);
            int guess = -1;
            int count = -1;

            Console.WriteLine("Let's Play Guess My Number!");
        
            while (guess != magicNumber)
            {
                Console.Write("What is your guess?");
                guess = int.Parse(Console.ReadLine());
                count++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You Guessed it!");
                    Console.WriteLine($"It took you {count} tries.");
                }
            }
            Console.Write("Do you want to play again? yes/no: ");
            playAgain = Console.ReadLine().ToLower();            
        }
    }
}