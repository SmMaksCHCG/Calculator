using System.Media;
using System.Windows;

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
}
