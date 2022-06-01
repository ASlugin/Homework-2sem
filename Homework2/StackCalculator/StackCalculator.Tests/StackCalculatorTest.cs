namespace StackCalculator.Tests;

using NUnit.Framework;
using System.Collections.Generic;

public class StackCalculatorTest
{
    private static IEnumerable<TestCaseData> StackCases
        => new TestCaseData[]
        {
            new TestCaseData(new StackOnArray()),
            new TestCaseData(new StackOnList()),
        };

    [TestCaseSource(nameof(StackCases))]
    [System.Obsolete]
    public void CalculateShallWorkCorrectlyWithPositiveNumbers(IStack stack)
    {
        Assert.AreEqual(15, Calculator.Calculate("5 3 + 7 +", stack));
        Assert.AreEqual(0, Calculator.Calculate("99 33 / 12 * 7 29 + -", stack));
        Assert.AreEqual(7, Calculator.Calculate("5 7 9 - -", stack));
        Assert.AreEqual(0.375, Calculator.Calculate("30 80 /", stack), 0.0001);
    }

    [TestCaseSource(nameof(StackCases))]
    public void CalculateShallWorkCorrectlyWithNegativeNumbers(IStack stack)
    {
        Assert.AreEqual(89, Calculator.Calculate("79 8 + -2 -", stack)); // Negative number after operation
        Assert.AreEqual(5, Calculator.Calculate("-2 -7 -", stack)); // Negative number at the begining of the expression 
        Assert.AreEqual(1, Calculator.Calculate("15 -2 * 6 -36 + /", stack)); // Negative number during the calculation
        Assert.AreEqual(-2, Calculator.Calculate("-18 9 /", stack)); // Result of the calculation is a negative number
    }

    [TestCaseSource(nameof(StackCases))]
    public void CalculateShallWorkCorrectlyIfExpressionContainOnlyOneNumber(IStack stack)
    {
        Assert.AreEqual(150, Calculator.Calculate("150", stack));
        Assert.AreEqual(-7, Calculator.Calculate("-7", stack));
        Assert.AreEqual(0, Calculator.Calculate("0", stack));
    }

    [TestCaseSource(nameof(StackCases))]
    public void CalculateShallReturnNullWhenDividinByZero(IStack stack)
    {
        Assert.IsNull(Calculator.Calculate("1234 0 /", stack));
        Assert.IsNull(Calculator.Calculate("17 9 -9 + /", stack));
    }

    [TestCaseSource(nameof(StackCases))]
    public void CalculateShallReturnNullIfExpressionIsIncorreclty(IStack stack)
    {
        Assert.IsNull(Calculator.Calculate("ab qwert /", stack));
        Assert.IsNull(Calculator.Calculate("IV XII * ", stack));
    }

    [TestCaseSource(nameof(StackCases))]
    public void CalculateShallReturnNullIfExpressionIsEmpty(IStack stack)
    {
        Assert.IsNull(Calculator.Calculate("", stack));
    }

    [TestCaseSource(nameof(StackCases))]
    public void CalculateShallReturnNullIfExpressionStartsWithOperation(IStack stack)
    {
        Assert.IsNull(Calculator.Calculate("+ 3 2", stack));
        Assert.IsNull(Calculator.Calculate("- 12 + 45 67", stack));
        Assert.IsNull(Calculator.Calculate("* -7 9", stack));
        Assert.IsNull(Calculator.Calculate("/ 5 9 3", stack));
    }
}
