class ReflectionActivity : Activity
{




    public ReflectionActivity(string startMessage, string endMessage) :
                        base(startMessage, endMessage)
    {
    }
    

    public void StartReflection()
    {
        Console.WriteLine(GetStartMessage());
        Console.WriteLine("How many 10 second cycles of pondering would you like to do?");
        int rotations = int.Parse(Console.ReadLine());
        _timer.SetDoUseSpinner(true);

        List<string> thinkPrompts = new() {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless." 
};
        Random random = new();
        int i = random.Next(thinkPrompts.Count - 1);
        Console.WriteLine(thinkPrompts[i]);
        _timer.SetTime(10);
        _timer.Run();
        for (int j = rotations; j > 0; j--)
        {
            List<string> questions = new(){
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };
            i = random.Next(questions.Count);
            Console.WriteLine(questions[i]);
            _timer.SetTime(10);
            _timer.Run();
        }

        Console.WriteLine(GetEndMessage());
    }
}