using System;
using Calculator.SimpleCalculatorFactory.Buttons;
using Calculator.SimpleCalculatorFactory.Factories;

Console.WriteLine("SimpleCalculatorFactory interactive demo (Factory Method)");

var engine = new CalculatorEngine();
Console.WriteLine("Команды: число, + - * /, =, C, CE, %, ±, sqrt, ^, log, sin, cos, MS, MR, exit");
string? input;
string? pendingOp = null;
double current = 0;
while (true)
{
    Console.Write("> ");
    input = Console.ReadLine();
    if (input == null) break;
    var token = input.Trim();
    if (token.Equals("exit", StringComparison.OrdinalIgnoreCase)) break;
    try
    {
        // числа
        if (double.TryParse(token, out var num))
        {
            current = num;
            Console.WriteLine($"Ввод: {current}");
            continue;
        }

        // бинарные операции
        if (token == "+" || token == "-" || token == "*" || token == "/")
        {
            engine.EnterNumber(current.ToString(System.Globalization.CultureInfo.InvariantCulture));
            engine.EnterOperator(token);
            Console.WriteLine($"Операция: {token}");
            continue;
        }

        if (token == "=")
        {
            var res = engine.Compute(current);
            Console.WriteLine($"= {res}");
            current = res;
            continue;
        }

        // функциональные
        if (token.Equals("C", StringComparison.OrdinalIgnoreCase)) { current = 0; Console.WriteLine("Cleared"); continue; }
        if (token.Equals("CE", StringComparison.OrdinalIgnoreCase)) { current = 0; Console.WriteLine("Cleared entry"); continue; }
        if (token == "%") { current = engine.ApplyUnary("%", current); Console.WriteLine(current); continue; }
        if (token == "±") { current = engine.ApplyUnary("±", current); Console.WriteLine(current); continue; }
        if (token.Equals("sqrt", StringComparison.OrdinalIgnoreCase) || token == "√") { current = engine.ApplyUnary("√", current); Console.WriteLine(current); continue; }
        if (token == "^") { current = engine.ApplyUnary("^", current); Console.WriteLine(current); continue; }
        if (token.Equals("log", StringComparison.OrdinalIgnoreCase)) { current = engine.ApplyUnary("log", current); Console.WriteLine(current); continue; }
        if (token.Equals("sin", StringComparison.OrdinalIgnoreCase)) { current = engine.ApplyUnary("sin", current); Console.WriteLine(current); continue; }
        if (token.Equals("cos", StringComparison.OrdinalIgnoreCase)) { current = engine.ApplyUnary("cos", current); Console.WriteLine(current); continue; }

        // память
        if (token.Equals("MS", StringComparison.OrdinalIgnoreCase)) { engine.MemoryStore(current); Console.WriteLine("Stored to memory"); continue; }
        if (token.Equals("MR", StringComparison.OrdinalIgnoreCase)) { var m = engine.MemoryRecall(); Console.WriteLine(m.HasValue ? m.Value.ToString() : "(empty)"); if (m.HasValue) current = m.Value; continue; }

        Console.WriteLine("Неизвестная команда");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}
