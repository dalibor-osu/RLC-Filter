using System.Windows;
using System.Windows.Controls;

namespace RLC_Filter.Pages;

public partial class MainMenu : UserControl
{
    Window mainWindow;
    
    public MainMenu(Window mainWindow)
    {
        this.mainWindow = mainWindow;
        InitializeComponent();
        
        
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}