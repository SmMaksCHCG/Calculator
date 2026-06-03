namespace Calculator.SimpleCalculatorFactory.Buttons;

public class PowerButton : Button
{
    private readonly double _power;
    public PowerButton(double power = 2) { _power = power; }
    public override string Press() => "^";
    public double Power => _power;
}
