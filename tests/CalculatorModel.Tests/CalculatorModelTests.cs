using Xunit;
using Calculator.SimpleCalculatorMVVM.Models;

namespace CalculatorModel.Tests;

public class CalculatorModelTests
{
    [Fact]
    public void Add_Works()
    {
        var m = new CalculatorModel();
        Assert.Equal(5, m.Add(2,3));
    }

    [Fact]
    public void Divide_ByZero_Throws()
    {
        var m = new CalculatorModel();
        Assert.Throws<System.DivideByZeroException>(() => m.Divide(1,0));
    }

    [Fact]
    public void Percent_Works()
    {
        var m = new CalculatorModel();
        Assert.Equal(0.5, m.Percent(50));
    }
}
