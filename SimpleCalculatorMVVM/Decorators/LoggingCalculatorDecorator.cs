using System;
using Calculator.SimpleCalculatorMVVM.Interfaces;

namespace Calculator.SimpleCalculatorMVVM.Decorators;

public class LoggingCalculatorDecorator : ICalculator
{
    private readonly ICalculator _inner;
    public LoggingCalculatorDecorator(ICalculator inner) { _inner = inner; }
    public double Add(double a, double b) { var r = _inner.Add(a,b); Console.WriteLine($"Add {a},{b} => {r}"); return r; }
    public double Subtract(double a, double b) { var r = _inner.Subtract(a,b); Console.WriteLine($"Sub {a},{b} => {r}"); return r; }
    public double Multiply(double a, double b) { var r = _inner.Multiply(a,b); Console.WriteLine($"Mul {a},{b} => {r}"); return r; }
    public double Divide(double a, double b) { var r = _inner.Divide(a,b); Console.WriteLine($"Div {a},{b} => {r}"); return r; }
    public double Percent(double value) { var r = _inner.Percent(value); Console.WriteLine($"Percent {value} => {r}"); return r; }
    public double Negate(double value) { var r = _inner.Negate(value); Console.WriteLine($"Neg {value} => {r}"); return r; }
    public double Sqrt(double value) { var r = _inner.Sqrt(value); Console.WriteLine($"Sqrt {value} => {r}"); return r; }
    public double Power(double value, double exponent = 2) { var r = _inner.Power(value, exponent); Console.WriteLine($"Power {value}^{exponent} => {r}"); return r; }
    public double Log10(double value) { var r = _inner.Log10(value); Console.WriteLine($"Log {value} => {r}"); return r; }
    public double Sin(double value) { var r = _inner.Sin(value); Console.WriteLine($"Sin {value} => {r}"); return r; }
    public double Cos(double value) { var r = _inner.Cos(value); Console.WriteLine($"Cos {value} => {r}"); return r; }
}
