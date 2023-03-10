using System.Numerics;

namespace RLC_Filter.RLCFilter.Parts;

public class Inductor : Component
{
    public Inductor(double value)
    {
        Value = value;
    }

    public override Complex GetImpedance(double angularFrequency) =>
        new (0, angularFrequency * Value);
}