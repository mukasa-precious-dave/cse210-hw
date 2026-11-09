using System;

namespace Fractions;

class Program
{
    static void Main(string[] args)
    {
        // Test Constructor 1: No parameters (1/1)
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        // Test Constructor 2: One parameter (5/1)
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        // Test Constructor 3: Two parameters (3/4)
        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        // Test another fraction (1/3)
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Test Getters and Setters explicitly
        Console.WriteLine("\n--- Testing Getters and Setters ---");
        Fraction testFraction = new Fraction();
        testFraction.SetTop(6);
        testFraction.SetBottom(7);
        Console.WriteLine($"Updated Fraction: {testFraction.GetFractionString()}");
        Console.WriteLine($"Updated Decimal: {testFraction.GetDecimalValue()}");
    }
}