public class Rectangle : Shape
{
    private double _length;
    private double _width;

    // Constructor accepting color, length, and width
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Override GetArea to calculate the area of a rectangle
    public override double GetArea()
    {
        return _length * _width;
    }
}