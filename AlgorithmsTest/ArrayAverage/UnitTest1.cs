using NUnit.Framework;
namespace AlgorithmsTest;

public class ArrayAverageCalculatorTest
{
    private ArrayAverageCalculator calculator;
    
    [SetUp]
    public void Setup()
    {
        calculator = new ArrayAverageCalculator();
    }

    [Test]
    public void TestAverageOfPositiveNumbers()
    {
        float[] numbers = { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f };
        float result = calculator.CalculateAverage(numbers);
        Assert.AreEqual(3.0f, result);
    }
    
    [Test]
    public void TestAverageOfNegativeNumbers()
    {
        float[] numbers = { -1.0f, -2.0f, -3.0f, -4.0f, -5.0f };
        float result = calculator.CalculateAverage(numbers);
        Assert.AreEqual(-3.0f, result);
    }

    [Test]
    public void TestAverageOfMixedNumbers()
    {
        float[] numbers = { -1.0f, 1.0f, -2.0f, 2.0f, -3.0f, 3.0f };
        float result = calculator.CalculateAverage(numbers);
        Assert.AreEqual(0.0f, result);
    }
}