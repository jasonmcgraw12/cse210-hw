class ListeningActivity : Activity
{




    public ListeningActivity(string startMessage, string endMessage) :
                        base(startMessage, endMessage)
    {
    }
    

    public void StartListening()
    {
        Console.WriteLine(GetStartMessage());
        Console.WriteLine("How long would you like to list things out for?");
        int rotations = int.Parse(Console.ReadLine());
        _timer.SetDoUseSpinner(true);

        List<string> listenPrompts = new() {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
};
        Random random = new();
        int i = random.Next(listenPrompts.Count - 1);
        Console.WriteLine(listenPrompts[i]);
        _timer.SetTime(5);
        _timer.Run();

        Console.WriteLine("List as many examples as you can think of.");
        _timer.StartStopwatch();
        int numberOfInputs = 0;
        while (_timer.CheckStopwatch() <= rotations)
        {
            numberOfInputs++;
            Console.ReadLine();
        }
        Console.WriteLine($"You listed {numberOfInputs} things!");
        _timer.EndStopwatch();
        Console.WriteLine(GetEndMessage());
    }
}