using System;
using Calculator.SimpleCalculatorFactory.Buttons;
using Calculator.SimpleCalculatorFactory.Factories;

Console.WriteLine("SimpleCalculatorFactory demo (Factory Method)");

// Демонстрация: собираем выражение 12 + 3 =
var creators = new ButtonCreator[] {
    new DigitButtonCreator(1), new DigitButtonCreator(2),
    new OperatorButtonCreator("+"),
    new DigitButtonCreator(3), new EqualsButtonCreator()
};

var inputTokens = new System.Collections.Generic.List<string>();
foreach (var c in creators)
{
    var btn = c.Create();
    var tok = btn.Press();
    Console.Write(tok + " ");
    inputTokens.Add(tok);
}
Console.WriteLine();

// Простая логика парсинга демонстрации
try
{
    // собрать число из последовательных цифр
    var tokens = inputTokens;
    double? left = null;
    string? op = null;
    double? right = null;
    string currentNumber = "";
    foreach (var t in tokens)
    {
        if (int.TryParse(t, out _)) { currentNumber += t; continue; }
        if (t == "+" || t == "-" || t == "*" || t == "/")
        {
            if (currentNumber != "") { left = double.Parse(currentNumber); currentNumber = ""; }
            op = t; continue;
        }
        if (t == "=") { if (currentNumber != "") right = double.Parse(currentNumber); }
    }
    if (left.HasValue && op != null && right.HasValue)
    {
        var engine = new CalculatorEngine();
        engine.EnterNumber(left.Value.ToString(System.Globalization.CultureInfo.InvariantCulture));
        engine.EnterOperator(op);
        var result = engine.Compute(right.Value);
        Console.WriteLine($"Результат: {result}");
    }
    else
    {
        Console.WriteLine("Не удалось распознать выражение.");
    }
}
catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
