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

public class ClearEntryButtonCreator : ButtonCreator
{
    public override Button Create() => new Buttons.ClearEntryButton();
}

public class PercentButtonCreator : ButtonCreator
{
    public override Button Create() => new Buttons.PercentButton();
}

public class PlusMinusButtonCreator : ButtonCreator
{
    public override Button Create() => new Buttons.PlusMinusButton();
}

public class SqrtButtonCreator : ButtonCreator
{
    public override Button Create() => new Buttons.SqrtButton();
}

public class PowerButtonCreator : ButtonCreator
{
    private readonly double _power;
    public PowerButtonCreator(double power = 2) { _power = power; }
    public override Button Create() => new Buttons.PowerButton(_power);
}

public class LogButtonCreator : ButtonCreator
{
    public override Button Create() => new Buttons.LogButton();
}

public class SinButtonCreator : ButtonCreator
{
    public override Button Create() => new Buttons.SinButton();
}

public class CosButtonCreator : ButtonCreator
{
    public override Button Create() => new Buttons.CosButton();
}

public class MemoryStoreButtonCreator : ButtonCreator
{
    public override Button Create() => new Buttons.MemoryStoreButton();
}

public class MemoryRecallButtonCreator : ButtonCreator
{
    public override Button Create() => new Buttons.MemoryRecallButton();
}
