using System;
using RLC_Filter.RLCFilter.FrequencyTypes;
using RLC_Filter.RLCFilter.Parts;

namespace RLC_Filter.RLCFilter;

public abstract class Filter
{
    public Resistor Resistor { get; }
    public Capacitor Capacitor { get; }
    public Inductor Inductor { get; }
    
    
    public string Name { get; protected init; }

    public Filter(double resistorValue, double capacitorValue, double inductorValue)
    {
        Resistor = new Resistor(resistorValue);
        Capacitor = new Capacitor(capacitorValue);
        Inductor = new Inductor(inductorValue);
    }

    public Filter(FilterComponents components)
    {
        Resistor = new Resistor(components.Resistor);
        Capacitor = new Capacitor(components.Capacitor);
        Inductor = new Inductor(components.Inductor);
    }

    protected double GetDenominator(AngularFrequency angularFrequency) => 
        Math.Sqrt(Math.Pow(Resistor.Value, 2) + Math.Pow(angularFrequency * Inductor.Value + 1 / (angularFrequency * Capacitor.Value), 2));
    

    public abstract double FrequencyResponse(AngularFrequency angularFrequency);
    public double FrequencyResponseInDb(AngularFrequency angularFrequency) =>
        20 * Math.Log10(FrequencyResponse(angularFrequency));
}