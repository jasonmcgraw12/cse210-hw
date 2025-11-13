using System.Drawing;
using System.Net.NetworkInformation;

class Circle : Shape
{
    private double _radius;


    public Circle(Color color, double radius) : base(color)
    {
        _radius = radius;
    }
    public override double GetArea()
    {
        double pi = 3.14;
        return pi*_radius*_radius;
    }
}