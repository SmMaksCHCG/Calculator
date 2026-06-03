using System.Windows;
using Calculator.SimpleCalculatorMVVM.ViewModels;

namespace Calculator.SimpleCalculatorMVVM;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}
