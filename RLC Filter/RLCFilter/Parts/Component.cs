using System.Numerics;

namespace RLC_Filter.RLCFilter.Parts;

public abstract class Component
{
    public double Value { get; protected init; }
    public virtual Complex GetImpedance(double frequency) => new (Value, 0);
}