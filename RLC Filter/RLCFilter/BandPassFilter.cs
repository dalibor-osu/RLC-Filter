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
}