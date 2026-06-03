using System;
using Calculator.SimpleCalculator;

var calc = new Calculator();
Console.WriteLine("Простой калькулятор");
while (true)
{
    Console.Write("Введите выражение (пример: 2 + 3) или exit: ");
    var input = Console.ReadLine();
    if (input == null || input.Trim().ToLower() == "exit") break;
    var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length != 3) { Console.WriteLine("Неверный формат. Используйте: <число> <оператор> <число>"); continue; }
    if (!double.TryParse(parts[0], out var a) || !double.TryParse(parts[2], out var b)) { Console.WriteLine("Неверное число."); continue; }
    var op = parts[1];
    try {
        var result = op switch {
            "+" => calc.Add(a,b),
            "-" => calc.Subtract(a,b),
            "*" or "x" or "X" => calc.Multiply(a,b),
            "/" => calc.Divide(a,b),
            _ => throw new InvalidOperationException("Неизвестная операция")
        };
        Console.WriteLine($"= {result}");
    } catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
}
