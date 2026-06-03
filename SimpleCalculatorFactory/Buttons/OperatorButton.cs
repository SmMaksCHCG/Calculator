namespace Calculator.SimpleCalculatorFactory.Buttons;

public class OperatorButton : Button
{
    private readonly string _operation;
    public OperatorButton(string operation) { _operation = operation; }
    public override string Press() => _operation;
}
