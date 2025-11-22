using System.Drawing;

class EternalGoal : SimpleGoal
{
    public EternalGoal(bool isComplete, int points, string title, string description) : base (isComplete, points, title, description)
    {
        
    }


    public override int Complete()
    {
        return GivePoints(GetPoints());
    }
}