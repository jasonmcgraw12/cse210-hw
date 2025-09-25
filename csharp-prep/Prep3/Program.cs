using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        string responce = "yes";
        while (responce == "yes")
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 11);
            int guess;
            int numberOfGuesses = 0;
            do
            {
                Console.Write("Guess my number");
                string strGuess = Console.ReadLine();
                guess = int.Parse(strGuess); // can use try parse to check if it is convertable

                if (guess == number)
                {
                    Console.WriteLine("That's right!");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > number)
                {
                    Console.WriteLine("Lower");
                }

                numberOfGuesses++;
            }
            while (guess != number);
            Console.WriteLine($"It only took you {numberOfGuesses} guesses.");
            Console.WriteLine("Do you want to continue?");
            responce = Console.ReadLine();
        }
    }
}