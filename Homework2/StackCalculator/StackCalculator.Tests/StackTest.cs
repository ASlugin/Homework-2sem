namespace StackCalculator.Tests;

using NUnit.Framework;
using Stack;
using System.Collections.Generic;

public class StackTest
{
    [SetUp]
    public void Setup()
    {
    }

    private static IEnumerable<TestCaseData> StackCases
        => new TestCaseData[]
        {
            new TestCaseData(new StackOnArray()),
            new TestCaseData(new StackOnList()),
        };


    [TestCaseSource(nameof(StackCases))]
    public void PushShallWork(IStack stack)
    {
        stack.Push(1);
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestCaseSource(nameof(StackCases))]
    public void PopShallWorkCorrectly(IStack stack)
    {
        stack.Push(77.7);
        Assert.AreEqual(77.7, stack.Pop());
    }

    [TestCaseSource(nameof(StackCases))]
    public void PopFromEmptyStackShouldReturnNull(IStack stack)
    {
        Assert.IsNull(stack.Pop());
    }

    [TestCaseSource(nameof(StackCases))]
    public void PushAndPopShallLeaveStackEmpty(IStack stack)
    {
        stack.Push(-15);
        stack.Pop();
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestCaseSource(nameof(StackCases))]
    public void LastInFirstOut(IStack stack)
    {
        stack.Push(-10);
        stack.Push(33);
        stack.Push(123.456);
        Assert.AreEqual(stack.Pop(), 123.456);
        Assert.AreEqual(stack.Pop(), 33);
        Assert.AreEqual(stack.Pop(), -10);
    }
}