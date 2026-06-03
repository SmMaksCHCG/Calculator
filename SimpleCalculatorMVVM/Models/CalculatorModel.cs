namespace Calculator.SimpleCalculatorMVVM.Models;

public class CalculatorModel
{
    public double Add(double a, double b) => a + b;
    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;
    public double Divide(double a, double b) => b == 0 ? throw new System.DivideByZeroException() : a / b;
    public double Percent(double value) => value / 100.0;
    public double Negate(double value) => -value;
    public double Sqrt(double value) => value < 0 ? throw new System.InvalidOperationException("Корень из отрицательного числа") : System.Math.Sqrt(value);
    public double Power(double value, double exponent = 2) => System.Math.Pow(value, exponent);
    public double Log10(double value) => System.Math.Log10(value);
    public double Sin(double value) => System.Math.Sin(value);
    public double Cos(double value) => System.Math.Cos(value);
}
