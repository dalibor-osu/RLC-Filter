using System;
using RLC_Filter.RLCFilter.FrequencyTypes;

namespace RLC_Filter.RLCFilter;

public class HighPassFilter : Filter
{
    public HighPassFilter(double resistorValue, double capacitorValue, double inductorValue) : 
        base(resistorValue, capacitorValue, inductorValue)
    {
        Name = "High-pass";
    }

    public HighPassFilter(FilterComponents components) :
        base(components)
    {
        Name = "High-pass";
    }
    
    public override double FrequencyResponse(AngularFrequency angularFrequency) =>
        (angularFrequency * Inductor.Value) / GetDenominator(angularFrequency);

    public override double PhaseShift(AngularFrequency angularFrequency) =>
        Math.Atan(1 / (angularFrequency * Resistor.Value * Capacitor.Value)) * (180 / Math.PI);

    public override AngularFrequency CutoffFrequency() =>
        1 / (Math.Sqrt(Inductor.Value * Capacitor.Value));
}