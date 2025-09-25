using System;

class Program
{
    static void Main(string[] args)
    {
        string input = "";
        List<int> numberList = new List<int>();
        do
        {
            Console.WriteLine("Enter a list of numbers, type '0' when finished");
            input = Console.ReadLine();
            if (input != "0")
            {
                numberList.Add(int.Parse(input));
            }
        }
        while (input != "0");
        int total = 0;
        int largest = -999;
        foreach (int num in numberList)
        {
            total += num;
            if (num > largest)
            {
                largest = num;
            }
        }

        float avg = total / numberList.Count;
        Console.WriteLine($"The total is: {total}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number in the list is: {largest}");
        Console.WriteLine("The sorted list is:");
        numberList.Sort();
        foreach (int num in numberList)
        {
            Console.WriteLine(num);
        }
    }
}