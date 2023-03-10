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
}