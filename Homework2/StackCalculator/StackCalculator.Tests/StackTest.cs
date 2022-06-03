namespace StackCalculator.Tests;

using NUnit.Framework;
using System;
using System.Collections.Generic;

public class StackTest
{
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
        Assert.IsFalse(stack.IsEmpty);
    }

    [TestCaseSource(nameof(StackCases))]
    [Obsolete]
    public void PopShallWorkCorrectly(IStack stack)
    {
        stack.Push(77.7);
        Assert.AreEqual(77.7, stack.Pop(), 0.0001);
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
        Assert.IsTrue(stack.IsEmpty);
    }

    [TestCaseSource(nameof(StackCases))]
    [Obsolete]
    public void LastInFirstOut(IStack stack)
    {
        stack.Push(-10);
        stack.Push(33);
        stack.Push(123.456);
        Assert.AreEqual(123.456, stack.Pop(), 0.0001);
        Assert.AreEqual(33, stack.Pop());
        Assert.AreEqual(-10, stack.Pop());
    }
}