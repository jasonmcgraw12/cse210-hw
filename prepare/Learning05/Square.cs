using System.Drawing;

class Square : Shape
{
    private double _side;


    public Square(Color color, double side) : base(color)
    {
        _side = side;
    }
    public override double GetArea()
    {
        return _side*_side;
    }
}