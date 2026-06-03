using System;
using System.IO;
using System.Text.Json;

namespace Calculator.SimpleCalculatorMVVM.Config;

public static class ConfigLoader
{
    public static AppConfig? Load(string path, out string? error)
    {
        error = null;
        try
        {
            if (!File.Exists(path)) { error = "Config file not found."; return null; }
            var json = File.ReadAllText(path);
            var cfg = JsonSerializer.Deserialize<AppConfig>(json, new JsonSerializerOptions{PropertyNameCaseInsensitive=true});
            return cfg;
        }
        catch (JsonException jex) { error = "Invalid JSON: " + jex.Message; return null; }
        catch (Exception ex) { error = ex.Message; return null; }
    }
}
