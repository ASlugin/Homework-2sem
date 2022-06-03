namespace SkipList.Tests;

using NUnit.Framework;
using System;

public class Tests
{
    [Test]
    public void SkipListShallContainElementAfterAdd()
    {
        SkipList<int> list = new();
        list.Add(99);
        Assert.IsTrue(list.Contains(99));
        list.Add(-40);
        Assert.IsTrue(list.Contains(-40));
        list.Add(5);
        Assert.IsTrue(list.Contains(5));
    }

    [Test]
    public void PropertyCountOfSkipListShallIncreaseAfterAddAndDecreaseAfterRemove()
    {
        SkipList<char> list = new();
        Assert.AreEqual(0, list.Count);
        list.Add('2');
        Assert.AreEqual(1, list.Count);
        list.Add('#');
        Assert.AreEqual(2, list.Count);
        list.Remove('0');
        Assert.AreEqual(2, list.Count);
        list.Remove('2');
        Assert.AreEqual(1, list.Count);
    }

    [Test]
    public void IndexOfShallReturnCorrectIndex()
    {
        SkipList<int> list = new();
        list.Add(100);
        list.Add(19);
        list.Add(-20);
        list.Add(11);
        list.Add(4);
        list.Add(29);
        Assert.AreEqual(0, list.IndexOf(-20));
        Assert.AreEqual(1, list.IndexOf(4));
        Assert.AreEqual(2, list.IndexOf(11));
        Assert.AreEqual(3, list.IndexOf(19));
        Assert.AreEqual(4, list.IndexOf(29));
        Assert.AreEqual(5, list.IndexOf(100));

        Assert.AreEqual(-1, list.IndexOf(99));
    }

    [Test]
    public void InsertShallThrowNotSupportedException()
    {
        SkipList<char> list = new();
        list.Add('%');
        list.Add('#');
        Assert.Throws<NotSupportedException>(() => list.Insert(1, '@'));
    }

    [Test]
    public void SkipListShallBeEmptyAfterClear()
    {
        SkipList<int> list = new();
        list.Add(100);
        list.Add(19);
        list.Add(-20);
        list.Clear();
        Assert.AreEqual(0, list.Count);
    }

    [Test]
    public void CopyToShallWorkCorrectly()
    {
        SkipList<int> list = new();
        list.Add(2);
        list.Add(0);
        list.Add(4);
        list.Add(1);
        list.Add(3);
        var array = new int[list.Count];
        list.CopyTo(array, 0);
        for (int i = 0; i < list.Count; i++)
        {
            Assert.AreEqual(array[i], i);
        }

        array = new int[list.Count - 2];
        list.CopyTo(array, 2);
        for (int i = 0; i < list.Count - 2; i++)
        {
            Assert.AreEqual(array[i], i + 2);
        }
    }

    [Test]
    public void CopyToShallThrowExceptionIfLengthArraySmall()
    {
        SkipList<int> list = new();
        list.Add(2);
        list.Add(0);
        list.Add(4);
        list.Add(1);
        list.Add(3);
        var array = new int[2];
        Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, 2));
    }

    [Test]
    public void ElementByIndexShallThrowExceptionIfIndexIsOutOfRange()
    {
        SkipList<int> list = new();
        list.Add(2);
        list.Add(0);
        list.Add(4);
        Assert.Throws<ArgumentOutOfRangeException>(() => list[4].Equals(1));
        Assert.Throws<ArgumentOutOfRangeException>(() => list[-1].Equals(1));
        Assert.Throws<ArgumentOutOfRangeException>(() => list[10].Equals(1));
    }

    [Test]
    public void ElementByIndexShallReturnCorrectElement()
    {
        SkipList<int> list = new();
        list.Add(19);
        list.Add(7);
        list.Add(12);
        Assert.AreEqual(7, list[0]);
        Assert.AreEqual(12, list[1]);
        Assert.AreEqual(19, list[2]);
    }

    [Test]
    public void AttemptModifyElementByIndexShallThrowException()
    {
        SkipList<int> list = new();
        list.Add(17);
        Assert.Throws<NotSupportedException>(() => list[0] = 1);
    }

    [Test]
    public void RemoveShallWorkCorrectly()
    {
        SkipList<string> list = new();
        list.Add("ololo");
        list.Add("ahaha");

        Assert.IsTrue(list.Contains("ololo"));
        Assert.IsTrue(list.Remove("ololo"));
        Assert.IsFalse(list.Contains("ololo"));

        Assert.IsFalse(list.Remove("qwerty"));
    }

    [Test]
    public void RemoveAtShallThrowExceptionIfIndexIsOutOfRange()
    {
        SkipList<double> list = new();
        list.Add(1.23);
        list.Add(-9.99);
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(2));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(10));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
    }

    [Test]
    public void ElementShallBeRemovedAfterRemoveAt()
    {
        SkipList<char> list = new();
        list.Add('a');
        list.Add('9');
        list.Add('9');

        list.RemoveAt(list.IndexOf('9') + 1);
        Assert.IsTrue(list.Contains('9'));
        list.RemoveAt(list.IndexOf('9'));
        Assert.IsFalse(list.Contains('9'));
    }

    [Test]
    public void ForeachMayBeUsedForSkipList()
    {
        SkipList<int> list = new();
        int[] array = { 4, 3, 5, 1, 0, 2 };
        for (int i = 0; i < array.Length; i++)
        {
            list.Add(array[i]);
        }

        int j = 0;
        foreach (var item in list)
        {
            Assert.AreEqual(item, j);
            ++j;
        }
        Assert.AreEqual(array.Length, j);
    }
}