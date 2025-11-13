using System;
using System.Drawing;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new();


        Console.WriteLine("Hello Learning05 World!");
        Color myColor = Color.FromName("red");
        Square mySquare = new Square(myColor, 2);
        shapes.Add(mySquare);

        Color myColor2 = Color.FromName("blue");
        Rectangle myRectangle = new Rectangle(myColor2, 2, 3);
        shapes.Add(myRectangle);

        Color myColor3 = Color.FromName("green");
        Circle myCircle = new Circle(myColor3, 2);
        shapes.Add(myCircle);

        foreach(Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
        
    }
}