class BreathingActivity : Activity
{
    public BreathingActivity(string startMessage, string endMessage) :
                        base(startMessage, endMessage){}
    

    public void StartBreathing()
    {
        Console.WriteLine(GetStartMessage());
        Console.WriteLine("How many 10 second cycles of breathing would you like to do?");
        int rotations = int.Parse(Console.ReadLine());
        _timer.SetDoUseSpinner(false);
        for (int i = rotations; i > 0; i--)
        {
            Console.WriteLine("Breathe in ");
            _timer.SetTime(5);
            _timer.Run();
            Console.WriteLine("Breathe out ");
            _timer.SetTime(5);
            _timer.Run();
        }

        Console.WriteLine(GetEndMessage());
    }
}