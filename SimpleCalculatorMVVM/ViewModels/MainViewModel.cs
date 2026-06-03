using System.ComponentModel;
using System.Runtime.CompilerServices;
using Calculator.SimpleCalculatorMVVM.Models;

namespace Calculator.SimpleCalculatorMVVM.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly CalculatorModel _model = new();
    private readonly Commands.CommandInvoker _invoker = new();
    private readonly Interfaces.ICalculator _calculator;
    private string _display = "0";
    public string Display { get => _display; set { _display = value; OnPropertyChanged(); } }

    private double? _left;
    private string? _op;

    public RelayCommand DigitCommand { get; }
    public RelayCommand OperatorCommand { get; }
    public RelayCommand EqualsCommand { get; }
    public RelayCommand ClearCommand { get; }
    public RelayCommand UnaryCommand { get; }
    public RelayCommand MemoryStoreCommand { get; }
    public RelayCommand MemoryRecallCommand { get; }
    public RelayCommand UndoCommand { get; }

    public MainViewModel()
    {
        // build calculator pipeline: Adapter -> Proxy -> LoggingDecorator
        var adapter = new Adapters.CalculatorAdapter(_model);
        var proxy = new Proxies.CachingCalculatorProxy(adapter);
        _calculator = new Decorators.LoggingCalculatorDecorator(proxy);

        DigitCommand = new RelayCommand(p => EnterDigit(p?.ToString()));
        OperatorCommand = new RelayCommand(p => { var s = p?.ToString(); if (s == "^") ApplyUnary(s); else EnterOperator(s); });
        EqualsCommand = new RelayCommand(_ => Compute());
        ClearCommand = new RelayCommand(_ => { Display = "0"; _left = null; _op = null; });
        UnaryCommand = new RelayCommand(p => ApplyUnary(p?.ToString()));
        MemoryStoreCommand = new RelayCommand(_ => _memory = double.Parse(Display, System.Globalization.CultureInfo.InvariantCulture));
        MemoryRecallCommand = new RelayCommand(_ => { if (_memory.HasValue) Display = _memory.Value.ToString(System.Globalization.CultureInfo.InvariantCulture); });
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
        var cmd = new Commands.BinaryCommand(_model, _left.Value, right, _op);
        var res = _invoker.ExecuteCommand(cmd);
        Display = res.ToString(System.Globalization.CultureInfo.InvariantCulture);
        _left = null; _op = null;
    }

    private double? _memory;

    private void ApplyUnary(string? op)
    {
        if (string.IsNullOrEmpty(op)) return;
        var val = double.Parse(Display, System.Globalization.CultureInfo.InvariantCulture);
        var res = op switch
        {
            "%" => _model.Percent(val),
            "±" => _model.Negate(val),
            "√" or "sqrt" => _model.Sqrt(val),
            "^" => _model.Power(val),
            "log" => _model.Log10(val),
            "sin" => _model.Sin(val),
            "cos" => _model.Cos(val),
            _ => val
        };
        Display = res.ToString(System.Globalization.CultureInfo.InvariantCulture);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
