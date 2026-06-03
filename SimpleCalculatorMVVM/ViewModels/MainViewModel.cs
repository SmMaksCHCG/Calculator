using System.ComponentModel;
using System.Runtime.CompilerServices;
using Calculator.SimpleCalculatorMVVM.Models;

namespace Calculator.SimpleCalculatorMVVM.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly CalculatorModel _model = new();
    private string _display = "0";
    public string Display { get => _display; set { _display = value; OnPropertyChanged(); } }

    private double? _left;
    private string? _op;

    public RelayCommand DigitCommand { get; }
    public RelayCommand OperatorCommand { get; }
    public RelayCommand EqualsCommand { get; }
    public RelayCommand ClearCommand { get; }

    public MainViewModel()
    {
        DigitCommand = new RelayCommand(p => EnterDigit(p?.ToString()));
        OperatorCommand = new RelayCommand(p => EnterOperator(p?.ToString()));
        EqualsCommand = new RelayCommand(_ => Compute());
        ClearCommand = new RelayCommand(_ => { Display = "0"; _left = null; _op = null; });
    }

    private void EnterDigit(string? d)
    {
        if (string.IsNullOrEmpty(d)) return;
        if (Display == "0") Display = d; else Display += d;
    }

    private void EnterOperator(string? op)
    {
        if (string.IsNullOrEmpty(op)) return;
        _left = double.Parse(Display, System.Globalization.CultureInfo.InvariantCulture);
        _op = op;
        Display = "0";
    }

    private void Compute()
    {
        if (!_left.HasValue || _op == null) return;
        var right = double.Parse(Display, System.Globalization.CultureInfo.InvariantCulture);
        var res = _op switch
        {
            "+" => _model.Add(_left.Value, right),
            "-" => _model.Subtract(_left.Value, right),
            "*" => _model.Multiply(_left.Value, right),
            "/" => _model.Divide(_left.Value, right),
            _ => 0
        };
        Display = res.ToString(System.Globalization.CultureInfo.InvariantCulture);
        _left = null; _op = null;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
