using System.Drawing;
using System.Text.RegularExpressions;

class NumberedGoal : SimpleGoal
{
    private int _currentChecks = 0;
    private int _maxChecks;
    private int _completionPoints;

    public NumberedGoal(bool isComplete, int points, int completionPoints, int currentChecks, int maxChecks, string title, string description) : base (isComplete, points, title, description)
    {
        _currentChecks = currentChecks;
        _maxChecks = maxChecks;
        _completionPoints = completionPoints;
    }

    public override string GetInfo()
    {
        return base.GetInfo()+$"||{_completionPoints}||{_currentChecks}||{_maxChecks}";
    }

    public int GetCompletionPoints()
    {
        return _completionPoints;
    }

    public override int Complete()
    {
        // add points to total
        if (!CheckIsComplete())
        {
            _currentChecks++;
            if (_currentChecks >= _maxChecks)
            {
                return GivePoints(GetCompletionPoints()) + base.Complete();
            }
            else
            {
                return GivePoints(GetPoints());
            }
        }
        return 0;
    }

    public override void Display()
    {
        Console.Write($"{_currentChecks}/{_maxChecks}");
        base.Display();
    }
}