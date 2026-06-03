namespace Calculator.SimpleCalculatorMVVM.Interfaces;

public interface ICalculator
{
    double Add(double a, double b);
    double Subtract(double a, double b);
    double Multiply(double a, double b);
    double Divide(double a, double b);
    double Percent(double value);
    double Negate(double value);
    double Sqrt(double value);
    double Power(double value, double exponent = 2);
    double Log10(double value);
    double Sin(double value);
    double Cos(double value);
}
