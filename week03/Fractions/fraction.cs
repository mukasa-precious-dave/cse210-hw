namespace Fractions;

public class Fraction
{
    private int _top;
    private int _bottom;

    // 1. Constructor with no parameters (initializes to 1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 2. Constructor with one parameter for the top (denominator defaults to 1)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // 3. Constructor with two parameters for top and bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters and Setters
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

    // Methods to return representations
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}