using System;
using RLC_Filter.RLCFilter.FrequencyTypes;
using RLC_Filter.RLCFilter.Parts;

namespace RLC_Filter.RLCFilter;

public class BandPassFilter : Filter
{
    public BandPassFilter(double resistorValue, double capacitorValue, double inductorValue) :
        base(resistorValue, capacitorValue, inductorValue)
    {
        Name = "Band-pass";
    }

    public BandPassFilter(FilterComponents components) :
        base(components)
    {
        Name = "Band-pass";
    }

    public override double FrequencyResponse(AngularFrequency angularFrequency) =>
        Resistor.Value / GetDenominator(angularFrequency);

    public override double PhaseShift(AngularFrequency angularFrequency) =>
        (Math.PI / 2 - Math.Atan(((2 * QualityFactor() * angularFrequency) / Freq()) +
                                Math.Sqrt(4 * Math.Pow(QualityFactor(), 2) - 1)) -
        Math.Atan(((2 * QualityFactor() * angularFrequency) / Freq()) -
                  Math.Sqrt(4 * Math.Pow(QualityFactor(), 2) - 1))) * (180 / Math.PI);

    private double QualityFactor() =>
        Math.Sqrt(Inductor.Value / (Capacitor.Value * Math.Pow(Resistor.Value, 2)));

    private double Freq() =>
        1 / (Resistor.Value * Capacitor.Value);
}