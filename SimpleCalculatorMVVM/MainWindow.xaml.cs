using System.Windows;
using Calculator.SimpleCalculatorMVVM.ViewModels;

namespace Calculator.SimpleCalculatorMVVM;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
        // Load configuration
        var cfgPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "SimpleCalculatorMVVM", "Config", "appsettings.json");
        var cfg = Config.ConfigLoader.Load(cfgPath, out var err);
        if (cfg == null)
        {
            System.Console.WriteLine("Config load error: " + err);
        }
        else
        {
            if (cfg.Width.HasValue) this.Width = cfg.Width.Value;
            if (cfg.Height.HasValue) this.Height = cfg.Height.Value;
            try {
                if (!string.IsNullOrEmpty(cfg.BackgroundColor)) this.Background = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString(cfg.BackgroundColor);
                if (!string.IsNullOrEmpty(cfg.ForegroundColor)) this.Foreground = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString(cfg.ForegroundColor);
                if (!string.IsNullOrEmpty(cfg.FontFamily)) this.FontFamily = new System.Windows.Media.FontFamily(cfg.FontFamily);
                if (cfg.FontSize.HasValue) this.FontSize = cfg.FontSize.Value;
            } catch (Exception ex) { System.Console.WriteLine("Config apply error: " + ex.Message); }
            // apply preset styles
            if (!string.IsNullOrEmpty(cfg.Preset))
            {
                try
                {
                    var presetPath = $"/SimpleCalculatorMVVM;component/Resources/Presets/{cfg.Preset}.xaml";
                    var rd = new System.Windows.ResourceDictionary() { Source = new System.Uri(presetPath, System.UriKind.RelativeOrAbsolute) };
                    this.Resources.MergedDictionaries.Add(rd);
                    // apply preset background if provided
                    if (this.Resources.Contains("PresetBackground")) this.Background = (System.Windows.Media.Brush)this.Resources["PresetBackground"];
                    if (this.Resources.Contains("PresetForeground")) this.Foreground = (System.Windows.Media.Brush)this.Resources["PresetForeground"];
                }
                catch (Exception ex) { System.Console.WriteLine("Preset load error: " + ex.Message); }
            }
        }
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
