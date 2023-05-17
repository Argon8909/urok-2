namespace FiguresLib;

using System;

[AttributeUsage(AttributeTargets.Class)] // | AttributeTargets.Method)
public class AngleAttribute : Attribute
{
    public AngleAttribute(int angle)
    {
        _angle = angle;
    }

    public readonly int _angle;
}