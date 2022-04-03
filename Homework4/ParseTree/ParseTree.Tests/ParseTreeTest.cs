namespace ParseTree.Tests;

using NUnit.Framework;
using System;
using ParseTree;


public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    private double CreateTreeAndCalculateExpression(string expression)
    {
        Tree parseTree = new Tree(expression);
        return parseTree.Calculate();
    }

    [TestCase("+ 7 5", ExpectedResult = 12)]
    [TestCase("- -15 5", ExpectedResult = -20)]
    [TestCase("* 19 -4", ExpectedResult = -76)]
    [TestCase("/ 115 4", ExpectedResult = 28.75)]
    [TestCase("(* 4 (+ (/ 18 -3) (- (* (- 7 -3) 12) 50)))", ExpectedResult = 256)]
    [TestCase("+ (/ 13 (- 5 3) (/ (+ 1 1) (+ 4 1))", ExpectedResult = 6.9)]
    public double CorrectExpressions(string expression)
        => CreateTreeAndCalculateExpression(expression);

    [TestCase("/ 5 0")]
    [TestCase("( * ( + 12 6 ) (/ 14 (+ -10 10)))")]
    [TestCase("(/ 21 (- (* 2 5) 10))")]
    public void DivideByZero(string expression)
    {
        Assert.Throws<DivideByZeroException>(() => CreateTreeAndCalculateExpression(expression));
    }

    [TestCase("5 * 8")]
    [TestCase("+ 7 9 8")]
    [TestCase("(/ 48 (-47 7))")]
    [TestCase("(* 4.2 5.1)")]
    [TestCase("{- [ + 2 5 ]}")]
    public void IncorrectExpression(string expression)
    {
        Assert.Throws<ArgumentException>(() => CreateTreeAndCalculateExpression(expression));
    }
}
