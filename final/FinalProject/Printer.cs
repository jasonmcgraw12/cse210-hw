public class Printer
{
    public static void PauseInput()
    {
        Console.WriteLine("(Press 'enter' to continue)");
        Console.Read();
    }

    public static void PrintError(string error)
    {
        Console.WriteLine("Error: "+error);
        PauseInput();
    }
}