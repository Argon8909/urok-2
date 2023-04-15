namespace FiguresLib;

public interface IDescriptor
{
    public FigureType FigureType { get; }
    public string GetTitle();
}