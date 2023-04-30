using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;
using RLC_Filter.RLCFilter;
using RLC_Filter.RLCFilter.FrequencyTypes;

namespace RLC_Filter.Pages;

public partial class FilterEditor : UserControl
{
    private MainViewModel _model;
    private FilterTypes _type;
    private readonly FilterComponents _defaultComponents = new (1, 0.005, 0.005);

    public FilterEditor(FilterTypes type)
    {
        _type = type;
        InitializeComponent();
        
        _model = DataContext as MainViewModel;
        _model.Filter = GetFilterFromType(_type);
        
        InitializeTextBoxes();
    }

    private void InitializeTextBoxes()
    {
        StartXBox.Text = 1.ToString();
        EndXBox.Text = 1000.ToString();
        PointsBox.Text = 10000.ToString();

        ResistorBox.Text = _model.Filter.Resistor.Value.ToString();
        CapacitorBox.Text = _model.Filter.Capacitor.Value.ToString();
        InductorBox.Text = _model.Filter.Capacitor.Value.ToString();
    }

    private Filter GetFilterFromType(FilterTypes type)
    {
        return type switch
        {
            FilterTypes.BandPass => new BandPassFilter(_defaultComponents),
            FilterTypes.HighPass => new HighPassFilter(_defaultComponents),
            FilterTypes.BandStop => new BandStopFilter(_defaultComponents),
            _ => new LowPassFilter(_defaultComponents)
        };
    }
    
    private Filter GetFilterFromType(FilterTypes type, FilterComponents components)
    {
        return type switch
        {
            FilterTypes.BandPass => new BandPassFilter(components),
            FilterTypes.HighPass => new HighPassFilter(components),
            FilterTypes.BandStop => new BandStopFilter(components),
            _ => new LowPassFilter(components)
        };
    }

    private void ValueBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        double resistor, capacitor, inductor;

        if (double.TryParse(ResistorBox.Text, out resistor) &&
            double.TryParse(CapacitorBox.Text, out capacitor) &&
            double.TryParse(InductorBox.Text, out inductor))
        {
            _model.Filter = GetFilterFromType(_type, new FilterComponents(resistor, capacitor, inductor));
            CutoffBox.Content = Math.Round((Frequency)_model.Filter.CutoffFrequency(), 2);
        }
    }

    private void GraphPropertyBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        double startX, endX;
        int numberOfPoints;
        if (double.TryParse(StartXBox.Text, out startX) && 
            double.TryParse(EndXBox.Text, out endX) &&
            int.TryParse(PointsBox.Text, out numberOfPoints))
            _model.ChangeAxes(startX, endX, numberOfPoints);
    }

    private void BackBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as MainWindow;
        window.ContentControl.Content = new MainMenu(window);
    }
}