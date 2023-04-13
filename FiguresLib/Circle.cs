namespace FiguresLib;

public class Circle : Figure
{
    private double _r;

    public Circle(double r, int figureId) : base(figureId) 
    {
        _r = r;
    }
        
    public double R => _r;
    public double Diameter => 2 * _r;

    public override double Area => Math.PI * Math.Pow(_r, 2);
    public override double Perimeter => 2 * Math.PI * _r; 
        
    public override FigureType FigureType => FigureType.Circle;
    
}