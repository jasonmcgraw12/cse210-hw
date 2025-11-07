using System.Diagnostics;
using System.Xml;

class SimpleTimer
{
    private int _waitTimeMilliSeconds;
    private bool _doUseSpinner;
    private Stopwatch _stopwatch;

    public SimpleTimer()
    {
        _waitTimeMilliSeconds = 1000;
    }


    public void SetTime(int waitTimeSeconds)
    {
        _waitTimeMilliSeconds = waitTimeSeconds * 1000;
    }


    public void SetDoUseSpinner(bool doUseSpinner)
    {
        _doUseSpinner = doUseSpinner;
    }


    public void Run()
    {
        int delayTime = 1000;
        int waitTimeSeconds = _waitTimeMilliSeconds / 1000;
        List<string> spinner = new() { "|", "/", "-", "\\", "|" };
        for (int i = waitTimeSeconds; i > 0; i--)
        {
            if (_doUseSpinner)
            {
                Console.Write($"\b{spinner[i % 4]}");
            }
            else
            {
                Console.Write($"\b{i}");
            }
            Thread.Sleep(delayTime);
            _waitTimeMilliSeconds -= delayTime;
        }
        Console.WriteLine();
    }


    public void StartStopwatch()
    {
        _stopwatch = new Stopwatch();
        _stopwatch.Start(); // keeps track of time, if it's greater than the time for reflection, then end reflecton (check time on enter)
    }


    public float CheckStopwatch()
    {
        return _stopwatch.ElapsedTicks/10000000;
    }
    

    public void EndStopwatch()
    {
        _stopwatch.Stop();
    }
}