using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("what is your favorite number? ");
        return int.Parse(Console.ReadLine());
    }
    static void PromtUserBirthYear(out int birthYear)
    {
        Console.Write("What year were you born? ");
        birthYear = int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int num)
    {
        int numSquared = num * num;
        return numSquared;
    }
    static void DisplayResult(string name, int numSquared, int birthYear)
    {
        Console.WriteLine($"Hello {name} your favorite number squared is"
        + $" {numSquared} and you will turn {2025 - birthYear} years old this year");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favNumber = PromptUserNumber();
        int birthYear = 0;
        PromtUserBirthYear(out birthYear);
        int numSquared = SquareNumber(favNumber);
        DisplayResult(name, numSquared, birthYear);
    }
}