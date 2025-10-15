using System.Dynamic;

class Fraction()
{
    private int _top;
    private int _bottom;



    public Fraction(int top, int bottom) : this()
    {
        _top = top;
        _bottom = bottom;
    }


    public int GetTop()
    {
        return _top;
    }


    public void SetTop(int top)
    {
        _top = top;
    }


    public int GetBottom()
    {
        return _bottom;
    }


    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }


    public string GetFractionString()
    {
        string fraction = _top.ToString() + "/" + _bottom.ToString();
        return fraction;
    }
    

    public double GetDecimalValue()
    {
        double fraction = (float)_top / _bottom;
        return fraction;
    }
}