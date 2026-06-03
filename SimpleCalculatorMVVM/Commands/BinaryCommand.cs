using Calculator.SimpleCalculatorMVVM.Models;

namespace Calculator.SimpleCalculatorMVVM.Commands;

public class BinaryCommand : ICalcCommand
{
    private readonly CalculatorModel _model;
    private readonly double _left;
    private readonly double _right;
    private readonly string _op;

    public BinaryCommand(CalculatorModel model, double left, double right, string op)
    {
        _model = model;
        _left = left;
        _right = right;
        _op = op;
    }

    public double Execute()
    {
        return _op switch
        {
            "+" => _model.Add(_left, _right),
            "-" => _model.Subtract(_left, _right),
            "*" => _model.Multiply(_left, _right),
            "/" => _model.Divide(_left, _right),
            _ => 0
        };
    }

    public double Undo()
    {
        // Простая реализация: вернуть левый операнд
        return _left;
    }
}
