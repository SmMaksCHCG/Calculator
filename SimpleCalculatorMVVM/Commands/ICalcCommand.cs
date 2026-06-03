namespace Calculator.SimpleCalculatorMVVM.Commands;

public interface ICalcCommand
{
    double Execute();
    double Undo();
}
