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
        -Math.Pow(
            Math.Tan((angularFrequency / (Resistor.Value * Capacitor.Value)) /
                     (1 * (Capacitor.Value / Inductor.Value) - Math.Pow(angularFrequency, 2))),
            -1);
}