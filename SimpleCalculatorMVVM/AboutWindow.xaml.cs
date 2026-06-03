using System.Media;
using System.Windows;
using System.Windows.Input;

namespace Calculator.SimpleCalculatorMVVM;

public partial class AboutWindow : Window
{
    public AboutWindow()
    {
        InitializeComponent();
    }

    private void BtnPlay_Click(object sender, RoutedEventArgs e)
    {
        // Play system beep as example (dynamic resource)
        SystemSounds.Beep.Play();
        // change cursor dynamically
        this.Cursor = Cursors.Hand;
    }

    private void BtnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    // show developer info using InfoService
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            var svc = new Calculator.InfoLib.InfoService();
            foreach (var d in svc.GetDevelopers())
            {
                // append as lines
                // find a TextBlock or just show MessageBox for demo
            }
        }
        catch { }
    }
}
