using System;
using System.Data;

namespace Calculator.EvaluationLib;

public class ExpressionEvaluator
{
    // Простая реализация через DataTable.Compute для учебных целей
    public double Evaluate(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression)) throw new ArgumentException("Expression empty");
        var table = new DataTable();
        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
        var value = table.Compute(expression, string.Empty);
        return Convert.ToDouble(value);
    }
}
