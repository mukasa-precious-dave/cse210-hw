public class Square : Shape
{
    private double _side;

    // Constructor accepting color and side, calling the base constructor
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override GetArea to calculate the area of a square
    public override double GetArea()
    {
        return _side * _side;
    }
}