using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RLC_Filter.Pages;
using RLC_Filter.RLCFilter;

namespace RLC_Filter.Components.MainMenu;

public partial class FilterButton : UserControl
{
    public FilterButton()
    {
        InitializeComponent();
    }

    public FilterTypes FilterType
    {
        get => (FilterTypes)GetValue(FilterTypeProperty);
        set => SetValue(FilterTypeProperty, value);
    }
    
    public static readonly DependencyProperty FilterTypeProperty =
        DependencyProperty.Register("FilterType", typeof(FilterTypes), typeof(FilterButton));
    
    private void OnLoad(object sender, RoutedEventArgs e)
    {
        string text = FilterType switch
        {
            FilterTypes.LowPass => "Low-pass",
            FilterTypes.HighPass => "High-pass",
            FilterTypes.BandStop => "Band-stop",
            _ => "Band-pass"
        };

        FilterBtnText.Text = text;
    }

    private void FilterButton_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) as MainWindow;
        window.ContentControl.Content = new FilterEditor(FilterType);
    }
}