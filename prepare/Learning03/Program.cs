using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the numerator: ");
        int top = int.Parse(Console.ReadLine());
        Console.WriteLine("What is the denominator: ");
        int bottom = int.Parse(Console.ReadLine());

        Fraction myFraction = new(top, bottom);
        Console.WriteLine(myFraction.GetFractionString());
        Console.WriteLine(myFraction.GetDecimalValue());
    }
}