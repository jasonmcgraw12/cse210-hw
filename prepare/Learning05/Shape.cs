using System.Drawing;

class Shape
{
    private Color _color;


    public Shape(Color color)
    {
        _color = color;
    }


    public Color GetColor()
    {
        return _color;
    }


    public void SetColor(Color color)
    {
        _color = color;
    }


    public virtual double GetArea()
    {
        return 1;
    }
}