namespace Calculator.SimpleCalculatorMVVM.Models;

public class CalculatorModel
{
    public double Add(double a, double b) => a + b;
    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;
    public double Divide(double a, double b) => b == 0 ? throw new System.DivideByZeroException() : a / b;
}
