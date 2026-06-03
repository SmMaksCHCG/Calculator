using System.Windows;
using Calculator.SimpleCalculatorMVVM.ViewModels;

namespace Calculator.SimpleCalculatorMVVM;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
        // set window icon from resources (static)
        try { this.Icon = (System.Windows.Media.ImageSource)FindResource("AppIcon"); } catch { }
    }

    private void About_Click(object sender, RoutedEventArgs e)
    {
        var w = new AboutWindow();
        w.Owner = this;
        w.ShowDialog();
    }
}
