using RLC_Filter.RLCFilter.FrequencyTypes;

namespace RLC_Filter.RLCFilter;

public class LowPassFilter : Filter
{
    public LowPassFilter(double resistorValue, double capacitorValue, double inductorValue) :
        base(resistorValue, capacitorValue, inductorValue)
    {
        Name = "Low-pass";
    }

    public LowPassFilter(FilterComponents components) :
        base(components)
    {
        Name = "Low-pass";
    }

    public override double FrequencyResponse(AngularFrequency angularFrequency) =>
        (1 / (angularFrequency * Capacitor.Value)) / GetDenominator(angularFrequency);
}