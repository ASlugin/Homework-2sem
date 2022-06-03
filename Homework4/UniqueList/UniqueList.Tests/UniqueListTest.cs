using NUnit.Framework;

namespace UniqueListTests;

public class UniqueListTest
{
    [Test]
    public void AddElementThatAlreadyExist()
    {
        var list = new UniqueList();
        list.Add(11, list.Size);
        list.Add(22, list.Size);
        Assert.Throws<AttemptToAddExistingValueException>(() => list.Add(11, 1));
        Assert.Throws<AttemptToAddExistingValueException>(() => list.Add(22, 0));
    }

    [Test]
    public void ChangeValueThatAlreadyExist()
    {
        var list = new UniqueList();
        list.Add(12, list.Size);
        list.Add(34, list.Size);
        Assert.Throws<AttemptToAddExistingValueException>(() => list.ChangeValueOfElement(12, 1));
        Assert.Throws<AttemptToAddExistingValueException>(() => list.ChangeValueOfElement(34, 0));
    }
}
