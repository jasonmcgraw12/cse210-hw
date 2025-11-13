using System.Drawing;

class Rectangle : Shape
{
    private double _hight;
    private double _width;


    public Rectangle(Color color, double width, double hight) : base(color)
    {
        _width = width;
        _hight = hight;
    }
    public override double GetArea()
    {
        return _width*_hight;
    }
}