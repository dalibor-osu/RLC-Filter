using System.Numerics;

namespace RLC_Filter.RLCFilter.Parts;

public class Capacitor : Component
{
    public Capacitor(double value)
    {
        Value = value;
    }

    public override Complex GetImpedance(double angularFrequency) =>
        new (0, 1 / (angularFrequency * Value));
}