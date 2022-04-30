using NUnit.Framework;
using Calculator;
using System.Globalization;
using System.Threading;

namespace Calculato.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
    }

    [TestCase("1+2+3+", ExpectedResult = "6+")]
    [TestCase("-4+7/1*", ExpectedResult = "3*")]
    [TestCase("1,56-0,56-", ExpectedResult = "1-")]
    [TestCase("3,5+7*4/2-7=", ExpectedResult = "14")]
    [TestCase("-3,4+1,5/", ExpectedResult = "-1,9/")]
    public string CorrectExpressionShallCalculateCorrectly(string text)
    {
        CalculatingClass calculating = new();
        foreach (var symbol in text)
        {
            calculating.TextForTextBox += symbol;
            if (!calculating.Validation())
            {
                Assert.Fail();
            }
        }
        return calculating.TextForTextBox;
    }

    [TestCase("5+21=", ExpectedResult = "26")]
    [TestCase("19-27=", ExpectedResult = "-8")]
    [TestCase("-4*5=", ExpectedResult = "-20")]
    [TestCase("125/40=", ExpectedResult = "3,125")]
    [TestCase("4,78=", ExpectedResult = "4,78")]
    [TestCase("35,=", ExpectedResult = "35,")]
    [TestCase("-79*=", ExpectedResult = "-79")]
    [TestCase("46-4,=", ExpectedResult = "46-4,")]
    public string ExpressionWithEqualShallCalculateCorrectly(string text)
    {
        CalculatingClass calculating = new();
        foreach (var symbol in text)
        {
            calculating.TextForTextBox += symbol;
            if (!calculating.Validation())
            {
                Assert.Fail();
            }
        }
        return calculating.TextForTextBox;
    }

    [TestCase("79/0=")]
    [TestCase("-4/0-")]
    [TestCase("7,98 / 0+")]
    [TestCase("-47,56/0/4")]
    [TestCase("4+7,1/0*7")]
    [TestCase("-75,4/0²")]
    [TestCase("57/0√")]
    public void DivisionByZEroShallNotPassValisation(string text)
    {
        CalculatingClass calculating = new();
        foreach (var symbol in text)
        {
            calculating.TextForTextBox += symbol;
            if (!calculating.Validation())
            {
                Assert.Pass();
            }
        }
        Assert.Fail();
    }

    [TestCase("-47√")]
    [TestCase("78-99√")]
    [TestCase("-70/10√")]
    [TestCase("50+9-101√")]
    public void SqrtOfNegativeNumberShallNotPassValidation(string text)
    {
        CalculatingClass calculating = new();
        foreach (var symbol in text)
        {
            calculating.TextForTextBox += symbol;
            if (!calculating.Validation())
            {
                Assert.Pass();
            }
        }
        Assert.Fail();
    }

    [TestCase("-7,98", 3, "", ExpectedResult = "-7")]
    [TestCase("123", 2, "46+78=", ExpectedResult = "224")]
    [TestCase("-37,09+7,9", 5, "4*2+", ExpectedResult = "-74,08+")]
    [TestCase("-37/0,1", 2, ",4*2-", ExpectedResult = "-185-")]
    [TestCase("64*", 1, "/2=", ExpectedResult = "32")]
    public string BackspaceShallWorkCorrectly(string text, int amountBack, string textAfterBack)
    {
        CalculatingClass calculating = new();
        foreach (var symbol in text)
        {
            calculating.TextForTextBox += symbol;
            if (!calculating.Validation())
            {
                Assert.Fail();
            }
        }
        for (int i = 0; i < amountBack; i++)
        {
            if (calculating.TextForTextBox.Length > 0)
            {
                calculating.TextForTextBox = calculating.TextForTextBox.Substring(0, calculating.TextForTextBox.Length - 1);
            }
            if (!calculating.validationForBackspace())
            {
                Assert.Fail();
            }
        }
        foreach (var symbol in textAfterBack)
        {
            calculating.TextForTextBox += symbol;
            if (!calculating.Validation())
            {
                Assert.Fail();
            }
        }
        return calculating.TextForTextBox;
    }
}
