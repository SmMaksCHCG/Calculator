using System.Collections.Generic;

namespace Calculator.SimpleCalculatorMVVM.Commands;

public class CommandInvoker
{
    private readonly Stack<ICalcCommand> _history = new();

    public double ExecuteCommand(ICalcCommand cmd)
    {
        var result = cmd.Execute();
        _history.Push(cmd);
        return result;
    }

    public double? Undo()
    {
        if (_history.Count == 0) return null;
        var cmd = _history.Pop();
        return cmd.Undo();
    }
}
