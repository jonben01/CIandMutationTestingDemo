using Calculator;

namespace Tests;

public class SimpleCalculatorTest
{
    [Test]
    public void Add()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var a = 2;
        var b = 3;
        
        // Act
        var result = calc.Add(a, b);
        
        // Assert
        Assert.That(result, Is.EqualTo(5));
    }
    
    
    
    [Test]
    public void Subtract()
    {
        var calc = new SimpleCalculator();
        var a = 10;
        var b = 5;
        var result = calc.Subtract(a, b);
        Assert.That(result, Is.EqualTo(5));
    }
    
    [Test]
    public void Multiply()
    {
        var calc = new SimpleCalculator();
        var a = 10;
        var b = 5;
        var result = calc.Multiply(a, b);
        Assert.That(result, Is.EqualTo(50));
    }
    
    [Test]
    public void Divide()
    {
        var calc = new SimpleCalculator();
        var a = 10;
        var b = 5;
        var result = calc.Divide(a, b);
        Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void DivideByZero_ThrowsException()
    {
        var calc = new SimpleCalculator();
        Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
    }
    
    //Input vs expected output
    [TestCase(0, 1)]
    [TestCase(1, 1)]
    [TestCase(5, 120)]
    public void Factorial_ValidInput_ReturnsCorrectResult(int input, int expected)
    {
        var calc = new SimpleCalculator();
        var result = calc.Factorial(input);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Factorial_NegativeInput_ThrowsException()
    {
        var calc = new SimpleCalculator();
        Assert.Throws<ArgumentException>(() => calc.Factorial(-1));
    }
    
    [TestCase(2, true)]
    [TestCase(3, true)]
    [TestCase(4, false)]
    [TestCase(5, true)]
    [TestCase(6, false)]
    [TestCase(7, true)]
    [TestCase(8, false)]
    [TestCase(9, false)]
    [TestCase(1, false)]
    [TestCase(0, false)]
    [TestCase(-3, false)]
    public void IsPrime_VariousInputs_ReturnsExpectedResult(int input, bool expected)
    {
        var calc = new SimpleCalculator();

        var result = calc.IsPrime(input);

        Assert.That(result, Is.EqualTo(expected));
    }


    
}