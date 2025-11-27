public class Printer
{
    public static void PauseInput(string message, bool shouldClear = true)
    {
        if (message != "")
        {
            Console.WriteLine(message);
        }
        Console.WriteLine("(Press 'enter' to continue)");
        Console.Read();
        if (shouldClear)
        {
            Console.Clear();
        }
    }

    public static void PrintError(string error)
    {
        PauseInput("Error: "+error);
    }
}