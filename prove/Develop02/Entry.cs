class Entry()
{
    public string _date;
    public string _prompt;
    public string _responce;


    public void Display()
    {
        Console.WriteLine("Date: " + _date);
        Console.WriteLine("Prompt: " + _prompt);
        Console.WriteLine("responce: " + _responce);
    }
}