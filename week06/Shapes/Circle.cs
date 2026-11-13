using System;

public class Circle : Shape
{
    private double _radius;

    // Constructor accepting color and radius
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override GetArea to calculate the area of a circle (pi * r^2)
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}