using System.Text.Json.Serialization;

namespace Calculator.SimpleCalculatorMVVM.Config;

public class AppConfig
{
    // Window
    public double? Width { get; set; }
    public double? Height { get; set; }

    // Appearance
    public string? BackgroundColor { get; set; }
    public string? ForegroundColor { get; set; }
    public string? FontFamily { get; set; }
    public double? FontSize { get; set; }
    // Theme: light / dark
    public string? Theme { get; set; }

    // Accessibility presets: normal, large
    public string? Accessibility { get; set; }

    // Optional DB connection string
    public string? ConnectionString { get; set; }
}
