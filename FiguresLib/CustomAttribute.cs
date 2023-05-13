namespace FiguresLib;

using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomAttribute : Attribute
{
    public CustomAttribute()
    {
    }
}