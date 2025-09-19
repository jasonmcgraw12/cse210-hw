using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");
        Console.WriteLine("Preparing to learn C#...");
        Console.Write("Give me a number:");
        string inputnum = Console.ReadLine();
        int num = ToNumber(inputnum) + 10;
        string tenNum = num.ToString();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine($"If I add 10 to your number you get... {tenNum}");

        Console.WriteLine("Sorry instructor or TA I got a bit carried away, I'll do the actual assignment now.\n");
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();
        Console.Write("what is your last name? ");
        string lastName = Console.ReadLine();
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
    static int ToNumber(string input)
    {
        bool canParse = int.TryParse(input, out int n);

        if (canParse)
        {
            int number = int.Parse(input);
            return number;
        }
        else
        {
            Console.WriteLine("That is not a number. You tried to trick me. \nBecause of this I shall pretend you typed \"7\"");
            return 7;
        }
    }
}