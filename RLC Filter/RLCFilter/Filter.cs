using System;
using RLC_Filter.RLCFilter.Parts;

namespace RLC_Filter.RLCFilter;

public abstract class Filter
{
    public Resistor Resistor { get; protected init; }
    public Capacitor Capacitor { get; protected init; }
    public Inductor Inductor { get; protected init; }
}