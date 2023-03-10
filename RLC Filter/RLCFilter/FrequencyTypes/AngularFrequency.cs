using System;

namespace RLC_Filter.RLCFilter.FrequencyTypes;

public struct AngularFrequency
{
    private double _value;

    private AngularFrequency(double value) => 
        _value = value;
    
    public static AngularFrequency operator /(AngularFrequency freq, double d)
    {
        return new AngularFrequency(freq._value / d);
    }
    
    public static implicit operator double(AngularFrequency freq)
        => freq._value;

    public static implicit operator AngularFrequency(double freq)
        => new (freq);
    
    public static explicit operator AngularFrequency(Frequency freq)
        => new (freq * 2 * Math.PI);
    
    public static AngularFrequency operator /(double d, AngularFrequency freq)
    {
        return new AngularFrequency(d / freq._value);
    }
        
}