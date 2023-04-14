using System;
namespace FiguresLib
{
    public class Figure: IParameters , IDescriptor
    {
        public virtual double Area { get; }
        
        public virtual double Perimeter { get; }
        
        public int FigureId { get; }
        public string Title => FigureType.ToString();

        public Figure(int figureId)
        {
            FigureId = figureId;
        }

        public string GetTitle()
        {
            return $"{FigureId}:{Title}";
        }
        
        public virtual FigureType FigureType { get; }
        
        
        
        
    }

    public enum FigureType
    {
        Circle, 
        Triangle, 
        Square
    }

    

   
    

    
    
    
    
}

/*
namespace Figures.figures
{
    



using System;

namespace Figures.figures
{
    public sealed class Square : Figure
    {
        private double _a;

        public Square(double a, int figureId) : base(figureId)
        {
            _a = a;
        }

        public double A => _a;

        public double Diagonal => Math.Sqrt(2) * _a;

        public override double Area => _a * _a;
        
        public override double Perimeter => 4 * _a;
        
        public override FigureType FigureType => FigureType.Square;

        
    }

    
}



using System;

namespace Figures.figures
{
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

        public override double Area => throw new Exception("Не умею");
        public override double Perimeter => _a + _b + _c;

        public override FigureType FigureType => FigureType.Triangle;

    }
}
*/
