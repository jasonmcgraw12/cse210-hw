using System;

class Program
{
    static void Main(string[] args)
    {
        WritingAssignment myAssignment = new("The Causes of World War II","Samuel Bennett", "Multiplication");
        Console.WriteLine(myAssignment.GetSummary());
        Console.WriteLine(myAssignment.GetWrittingInformation());
    }
}