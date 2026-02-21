using Calculator;

namespace Tests;

public class CachedCalculatorTest
{
    [Test]
    public void Add()
    {
        // Arrange
        var calc = new CachedCalculator();
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
        var calc = new CachedCalculator();
        var a = 10;
        var b = 5;
        var result = calc.Subtract(a, b);
        Assert.That(result, Is.EqualTo(5));
    }
    
    [Test]
    public void Multiply()
    {
        var calc = new CachedCalculator();
        var a = 10;
        var b = 5;
        var result = calc.Multiply(a, b);
        Assert.That(result, Is.EqualTo(50));
    }
    
    [Test]
    public void Divide()
    {
        var calc = new CachedCalculator();
        var a = 10;
        var b = 5;
        var result = calc.Divide(a, b);
        Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void DivideByZero_ThrowsException()
    {
        var calc = new CachedCalculator();
        Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
    }
    
    //Input vs expected output
    [TestCase(0, 1)]
    [TestCase(1, 1)]
    [TestCase(5, 120)]
    public void Factorial_ValidInput_ReturnsCorrectResult(int input, int expected)
    {
        var calc = new CachedCalculator();
        var result = calc.Factorial(input);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Factorial_NegativeInput_ThrowsException()
    {
        var calc = new CachedCalculator();
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
        var calc = new CachedCalculator();

        var result = calc.IsPrime(input);

        Assert.That(result, Is.EqualTo(expected));
    }


    private void AssertCachedCallTwice(TestDelegate action, CachedCalculator calc)
    {
        action();
        var countAfterFirst = calc._cache.Count;
        
        Assert.DoesNotThrow(action);
        Assert.That(calc._cache, Has.Count.EqualTo(countAfterFirst));
    }
    
    [Test]
    public void Add_Uses_Cache()
    {
        var calc = new CachedCalculator();
        AssertCachedCallTwice(() => calc.Add(1, 2), calc);
    }
    [Test]
    public void Multiply_Uses_Cache()
    {
        var calc = new CachedCalculator();
        AssertCachedCallTwice(() => calc.Multiply(1, 2), calc);
    }
    [Test]
    public void Subtract_Uses_Cache()
    {
        var calc = new CachedCalculator();
        AssertCachedCallTwice(() => calc.Subtract(10, 5), calc);
    }

    [Test]
    public void Divide_Uses_Cache()
    {
        var calc = new CachedCalculator();
        AssertCachedCallTwice(() => calc.Divide(10, 5), calc);
    }

    [Test]
    public void Factorial_Uses_Cache()
    {
        var calc = new CachedCalculator();
        AssertCachedCallTwice(() => calc.Factorial(5), calc);
    }
    [Test]
    public void IsPrime_Uses_Cache()
    {
        var calc = new CachedCalculator();
        AssertCachedCallTwice(() => calc.IsPrime(7), calc);
    }
    
    
    //the following tests try to cover caching related mutations by ensuring that the right key is stored in the cache
    //thus killing statement/block removal, as they won't add anything to the cache.
    
    [Test]
    public void IsPrime_FirstCall_StoresExpectedKeyInCache()
    {
        var calc = new CachedCalculator();

        calc.IsPrime(7);
        
        Assert.That(calc._cache.ContainsKey("7IsPrime"), Is.True);
        Assert.That(calc._cache, Has.Count.EqualTo(1));
    }

    [Test]
    public void Factorial_FirstCall_StoresExpectedKeyInCache()
    {
        var calc = new CachedCalculator();

        calc.Factorial(5);
        
        Assert.That(calc._cache.ContainsKey("5Factorial"), Is.True);
        Assert.That(calc._cache, Has.Count.EqualTo(1));
    }

    [Test]
    public void Add_FirstCall_StoresExpectedKeyInCache()
    {
        var calc = new CachedCalculator();

        calc.Add(2, 3);
        
        Assert.That(calc._cache.ContainsKey("2Add3"), Is.True);
        Assert.That(calc._cache, Has.Count.EqualTo(1));
    }
    
}