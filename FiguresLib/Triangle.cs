using System;

namespace FiguresLib;

[Custom]
public class Triangle : Figure
{
    private double _a, _b, _c;

    public Triangle(double a, double b, double c, int figureId) : base(figureId)
    {
        _a = a;
        _b = b;
        _c = c;
    }

    public double A => _a;

    public double B => _b;

    public double C => _c;

    public override double Area =>
        Math.Sqrt(Perimeter / 2 * (Perimeter / 2 - _a) * (Perimeter / 2 - _b) * (Perimeter / 2 - _c));

    public override double Perimeter => _a + _b + _c;

    public override FigureType FigureType => FigureType.Triangle;
}