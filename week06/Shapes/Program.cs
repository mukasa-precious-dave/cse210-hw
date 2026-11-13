using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create a list to hold Shape objects
        List<Shape> shapes = new List<Shape>();

        // 2. Create instances of different shapes and add them to the list
        Square sq = new Square("Red", 4.0);
        shapes.Add(sq);

        Rectangle rect = new Rectangle("Blue", 5.0, 3.0);
        shapes.Add(rect);

        Circle circ = new Circle("Green", 2.5);
        shapes.Add(circ);

        // 3. Iterate through the list, demonstrating polymorphism
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area:F2}.");
        }
    }
}