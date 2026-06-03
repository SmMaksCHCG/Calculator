using Calculator.SimpleCalculatorFactory.Buttons;

namespace Calculator.SimpleCalculatorFactory.Factories;

// Factory Method: каждый создатель отвечает за создание определённого типа кнопки.
public abstract class ButtonCreator
{
    public abstract Button Create();
}

public class DigitButtonCreator : ButtonCreator
{
    private readonly int _digit;
    public DigitButtonCreator(int digit) { _digit = digit; }
    public override Button Create() => new DigitButton(_digit);
}

public class OperatorButtonCreator : ButtonCreator
{
    private readonly string _op;
    public OperatorButtonCreator(string op) { _op = op; }
    public override Button Create() => new OperatorButton(_op);
}

public class EqualsButtonCreator : ButtonCreator
{
    public override Button Create() => new EqualsButton();
}

public class ClearButtonCreator : ButtonCreator
{
    public override Button Create() => new ClearButton();
}
