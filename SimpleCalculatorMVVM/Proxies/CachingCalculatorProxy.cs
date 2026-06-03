using System.Collections.Concurrent;
using Calculator.SimpleCalculatorMVVM.Interfaces;

namespace Calculator.SimpleCalculatorMVVM.Proxies;

public class CachingCalculatorProxy : ICalculator
{
    private readonly ICalculator _inner;
    private readonly ConcurrentDictionary<string, double> _cache = new();
    public CachingCalculatorProxy(ICalculator inner) { _inner = inner; }
    private double Cached(string key, System.Func<double> compute) => _cache.GetOrAdd(key, _ => compute());
    public double Add(double a, double b) => Cached($"add:{a}:{b}", () => _inner.Add(a,b));
    public double Subtract(double a, double b) => Cached($"sub:{a}:{b}", () => _inner.Subtract(a,b));
    public double Multiply(double a, double b) => Cached($"mul:{a}:{b}", () => _inner.Multiply(a,b));
    public double Divide(double a, double b) => Cached($"div:{a}:{b}", () => _inner.Divide(a,b));
    public double Percent(double value) => _inner.Percent(value);
    public double Negate(double value) => _inner.Negate(value);
    public double Sqrt(double value) => _inner.Sqrt(value);
    public double Power(double value, double exponent = 2) => _inner.Power(value, exponent);
    public double Log10(double value) => _inner.Log10(value);
    public double Sin(double value) => _inner.Sin(value);
    public double Cos(double value) => _inner.Cos(value);
}
