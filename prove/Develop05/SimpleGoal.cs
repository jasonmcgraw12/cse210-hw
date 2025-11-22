using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Swift;

class SimpleGoal
{
    private int _points;
    private string _title;
    private string _description;
    private bool _isComplete;



    public SimpleGoal(bool isComplete, int points, string title, string description)
    {
        _isComplete = isComplete;
        _points = points;
        _title = title;
        _description = description;
    }

    public bool CheckIsComplete()
    {
        return _isComplete;
    }

    public int GetPoints()
    {
        return _points;
    }

    public int GivePoints(int pointsGiven)
    {
        Console.WriteLine($"Completing this gave you {pointsGiven} more points!");
        return pointsGiven;
    }

    public string GetText()
    {
        string completeVisual = "  ";
        if (_isComplete)
        {
            completeVisual = "X";
        }
        return $"[{completeVisual}] {_title} ({_description}): {_points}";
    }

    public virtual string GetInfo()
    {
        return $"{GetType()}||{_isComplete}||{_isComplete}||{_title}||{_description}||{_points}";
    }

    public virtual int Complete()
    {
        if (_isComplete == false)
        {
            _isComplete = true;
            return GivePoints(GetPoints());
        }
        return 0;
    }

    public virtual void Display()
    {
        Console.WriteLine(GetText());
    }
}