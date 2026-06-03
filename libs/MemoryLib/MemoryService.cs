namespace Calculator.MemoryLib;

public class MemoryService
{
    private double? _memory;
    public void Store(double value) => _memory = value;
    public double? Recall() => _memory;
    public void Clear() => _memory = null;
}
