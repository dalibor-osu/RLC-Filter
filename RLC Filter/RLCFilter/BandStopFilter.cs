using System;
using RLC_Filter.RLCFilter.FrequencyTypes;

namespace RLC_Filter.RLCFilter;

public class BandStopFilter : Filter
{
    public BandStopFilter(double resistorValue, double capacitorValue, double inductorValue) : base(resistorValue,
        capacitorValue, inductorValue)
    {
        Name = "Band-stop";
    }

    public BandStopFilter(FilterComponents components) : base(components)
    {
        Name = "Band-stop";
    }

    public override double FrequencyResponse(AngularFrequency angularFrequency) =>
        (1 / (angularFrequency * Capacitor.Value) + Inductor.Value * angularFrequency) /
        GetDenominator(angularFrequency);

    public override double PhaseShift(AngularFrequency angularFrequency) =>
        (Math.PI / 2 - Math.Atan(((2 * QualityFactor() * angularFrequency) / Freq()) +
                                 Math.Sqrt(4 * Math.Pow(QualityFactor(), 2) - 1)) -
         Math.Atan(((2 * QualityFactor() * angularFrequency) / Freq()) -
                   Math.Sqrt(4 * Math.Pow(QualityFactor(), 2) - 1))) * (180 / Math.PI);

    private double QualityFactor() =>
        Math.Sqrt(Inductor.Value / (Capacitor.Value * Math.Pow(Resistor.Value, 2)));
    
    public override AngularFrequency CutoffFrequency() =>
        1 / Math.Sqrt(Capacitor.Value * Inductor.Value);

    private double Freq() =>
        CutoffFrequency();
}