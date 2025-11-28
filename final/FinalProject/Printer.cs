public class Printer
{
    public static string PauseInput(string message, bool shouldClear = true)
    {
        string input;
        if (message != "")
        {
            Console.WriteLine(message);
        }
        Console.WriteLine("(Press 'enter' to continue)");
        input = Console.ReadLine();
        if (shouldClear)
        {
            Console.Clear();
        }
        return input;
    }

    public static void PrintError(string error)
    {
        PauseInput("Error: "+error);
    }

    public static string WriteRead(string message, bool shouldClear = true)
    {
        string input;
        Console.WriteLine(message);
        input = Console.ReadLine();
        if (shouldClear)
        {
            Console.Clear();
        }
        return input;
    }

    public static string ChallengeWriteRead(string message, bool shouldClear = true)
    {
        return WriteRead(message + " (Enter 'yes' if you would like to perform the action)");
    }


}