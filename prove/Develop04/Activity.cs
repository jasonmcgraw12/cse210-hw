using System.Timers;
class Activity
{
    // I use a protected variable here because each activity needs to modify and run the timer.
    // sometimes multiple times in an activity.
    protected SimpleTimer _timer;
    private string _startMessage;
    private string _endMessage = "This activity is now over. Hope you had fun!";


    public Activity(string startMessage, string endMessage)
    {
        _timer = new();
        _startMessage = startMessage;
        _endMessage = endMessage;
    }


    public string GetStartMessage()
    {
        return _startMessage;
    }
    public string GetEndMessage()
    {
        return _endMessage;
    }
}