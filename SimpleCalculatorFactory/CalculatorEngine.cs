using System;
using System.Globalization;

namespace Calculator.SimpleCalculatorFactory;

// Простейший движок вычислений, поддерживает бинарные операции + - * /
public class CalculatorEngine
{
    private double? _left;
    private string? _op;
    private double? _memory;

    public void EnterNumber(string token)
    {
        if (!_left.HasValue)
        {
            _left = double.Parse(token, CultureInfo.InvariantCulture);
            return;
        }
        if (_op == null) // заменяем левый
            _left = double.Parse(token, CultureInfo.InvariantCulture);
    }

    public void EnterOperator(string op)
    {
        _op = op;
    }

    public double ApplyUnary(string op, double value)
    {
        return op switch
        {
            "%" => value / 100.0,
            "±" => -value,
            "√" => value < 0 ? throw new InvalidOperationException("Корень из отрицательного числа") : Math.Sqrt(value),
            "^" => Math.Pow(value, 2),
            "log" => Math.Log10(value),
            "sin" => Math.Sin(value),
            "cos" => Math.Cos(value),
            _ => throw new InvalidOperationException("Неизвестная унарная операция")
        };
    }

    public void MemoryStore(double value) => _memory = value;
    public double? MemoryRecall() => _memory;

    public double Compute(double right)
    {
        if (!_left.HasValue || _op == null) return right;
        return _op switch
        {
            "+" => _left.Value + right,
            "-" => _left.Value - right,
            "*" => _left.Value * right,
            "/" => right == 0 ? throw new DivideByZeroException() : _left.Value / right,
            _ => throw new InvalidOperationException("Неизвестная операция")
        };
    }
}
