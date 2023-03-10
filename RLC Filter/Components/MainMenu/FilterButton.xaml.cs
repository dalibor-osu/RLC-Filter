using System;
using System.Windows;
using System.Windows.Controls;

namespace RLC_Filter.Components.MainMenu;

public partial class FilterButton : UserControl
{
    public FilterButton()
    {
        InitializeComponent();
    }
    
    public string FilterType
    {
        get => (string)GetValue(FilterTypeProperty);
        set => SetValue(FilterTypeProperty, value);
    }
    
    public static readonly DependencyProperty FilterTypeProperty =
        DependencyProperty.Register("FilterType", typeof(string), typeof(FilterButton), new PropertyMetadata("Filter Type"));

    private void FilterButton_OnClick(object sender, RoutedEventArgs e)
    {
        TextBlock textBlock = FindName("FilterBtnText") as TextBlock;
        textBlock.Text = textBlock.Text + " Clicked";
    }
}