namespace RLC_Filter.RLCFilter;

public struct FilterComponents
{
    public double Resistor { get; set; }
    public double Capacitor { get; set; }
    public double Inductor { get; set; }

    public FilterComponents(double resistorValue, double capacitorValue, double inductorValue)
    {
        Resistor = resistorValue;
        Capacitor = capacitorValue;
        Inductor = inductorValue;
    }
}