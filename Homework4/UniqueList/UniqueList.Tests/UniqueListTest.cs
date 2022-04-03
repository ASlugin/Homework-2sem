using NUnit.Framework;
using System;
using System.Collections.Generic;
using UniqueList;

namespace UniqueList.Tests;

public class UniqueListTest
{
    [SetUp]
    public void SetUp()
    {
    }

    [Test]
    public void AddElementThatAlreadyExist()
    {
        UniqueList list = new UniqueList();
        list.Add(11, list.Size);
        list.Add(22, list.Size);
        Assert.Throws<AttemptToAddExistingValueException>(() => list.Add(11, 1));
        Assert.Throws<AttemptToAddExistingValueException>(() => list.Add(22, 0));
    }

    [Test]
    public void ChangeValueThatAlreadyExist()
    {
        UniqueList list = new UniqueList();
        list.Add(12, list.Size);
        list.Add(34, list.Size);
        Assert.Throws<AttemptToAddExistingValueException>(() => list.ChangeValueOfElement(12, 1));
        Assert.Throws<AttemptToAddExistingValueException>(() => list.ChangeValueOfElement(34, 0));
    }
}
