using Calculator.SimpleCalculatorMVVM.Interfaces;
using Calculator.SimpleCalculatorMVVM.Models;

namespace Calculator.SimpleCalculatorMVVM.Adapters;

public class CalculatorAdapter : ICalculator
{
    private readonly CalculatorModel _model;
    public CalculatorAdapter(CalculatorModel model) { _model = model; }
    public double Add(double a, double b) => _model.Add(a,b);
    public double Subtract(double a, double b) => _model.Subtract(a,b);
    public double Multiply(double a, double b) => _model.Multiply(a,b);
    public double Divide(double a, double b) => _model.Divide(a,b);
    public double Percent(double value) => _model.Percent(value);
    public double Negate(double value) => _model.Negate(value);
    public double Sqrt(double value) => _model.Sqrt(value);
    public double Power(double value, double exponent = 2) => _model.Power(value, exponent);
    public double Log10(double value) => _model.Log10(value);
    public double Sin(double value) => _model.Sin(value);
    public double Cos(double value) => _model.Cos(value);
}
