using System;

namespace RLC_Filter.RLCFilter.FrequencyTypes;

public struct Frequency
{
    private double _value;

    private Frequency(double value)
    {
        _value = value;
    }
    
    public static implicit operator Frequency(double value)
        => new (value);
    

    public static implicit operator double(Frequency freq)
        => freq._value;
    
    

    public static explicit operator Frequency(AngularFrequency angularFreq)
        => new (angularFreq / (2 * Math.PI));
    
}