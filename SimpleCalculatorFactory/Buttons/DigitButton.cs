namespace Calculator.SimpleCalculatorFactory.Buttons;

public class DigitButton : Button
{
    private readonly int _digit;
    public DigitButton(int digit) { _digit = digit; }
    public override string Press() => _digit.ToString();
}
