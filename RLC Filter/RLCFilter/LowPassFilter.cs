﻿using System;
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

    public override double PhaseShift(AngularFrequency angularFrequency) =>
        -Math.Atan(angularFrequency * Resistor.Value * Capacitor.Value) * (180 / Math.PI);

    public override AngularFrequency CutoffFrequency() =>
        1 / (Resistor.Value * Capacitor.Value);
}