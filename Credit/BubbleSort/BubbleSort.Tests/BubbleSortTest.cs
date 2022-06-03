namespace BubbleSort.Tests;

using NUnit.Framework;
using System.Collections.Generic;

public class ComparerString : IComparer<string>
{
    int IComparer<string>.Compare(string? x, string? y)
        => string.Compare(x, y);
}

public class ComparerPairBySecondItems : IComparer<(int, int)>
{
    int IComparer<(int, int)>.Compare((int, int) x, (int, int) y)
    {
        if (x.Item2 == y.Item2)
        {
            return 0;
        }
        return x.Item2 > y.Item2 ? 1 : -1;
    }
}

public class ComparerPairByFirstItemsDescendingOrder : IComparer<(int, int)>
{
    int IComparer<(int, int)>.Compare((int, int) x, (int, int) y)
    {
        if (x.Item1 == y.Item1)
        {
            return 0;
        }
        return x.Item1 > y.Item1 ? -1 : 1;
    }
}

public class Tests
{
    [Test]
    public void BubbleSortShallWorkCorrectly()
    {
        List<string> list = new();
        list.Add("abc");
        list.Add("ab");
        list.Add("abcde");
        list.Add("a");
        list.Add("abcd");
        var expectedList = new List<string> {"a", "ab", "abc", "abcd", "abcde"};
        
        Sort.BubbleSort(list, new ComparerString());
        Assert.AreEqual(expectedList, list);
    }

    [Test]
    public void BubbleSortOfPairsShallWorkCorreclty()
    {
        List<(int, int)> listOfPairs = new();
        listOfPairs.Add((9, 10));
        listOfPairs.Add((20, 5));
        listOfPairs.Add((30, 7));
        listOfPairs.Add((1, 2));
        var expectedList = new List<(int, int)> { (1, 2), (20, 5), (30, 7), (9, 10) };

        Sort.BubbleSort(listOfPairs, new ComparerPairBySecondItems());
        Assert.AreEqual(expectedList, listOfPairs);
    }

    [Test]
    public void BubbleSortOfPairsDescendingOrderShallWorkCorreclty()
    {
        List<(int, int)> listOfPairs = new();
        listOfPairs.Add((9, 10));
        listOfPairs.Add((20, 5));
        listOfPairs.Add((30, 7));
        listOfPairs.Add((1, 2));
        var expectedList = new List<(int, int)> { (30, 7), (20, 5), (9, 10), (1, 2) };

        Sort.BubbleSort(listOfPairs, new ComparerPairByFirstItemsDescendingOrder());
        Assert.AreEqual(expectedList, listOfPairs);
    }

    [Test]
    public void BubbleSortIntByDescendingOrderShallWorkCorreclty()
    {
        List<int> list = new();
        list.Add(2);
        list.Add(3);
        list.Add(7);
        list.Add(5);
        list.Add(4);
        list.Add(1);
        list.Add(6);
        list.Add(0);

        Sort.BubbleSort(list, new ComparerIntDescendingOrder());

        for (int i = 0; i < list.Count; i++)
        {
            Assert.AreEqual(7 - i, list[i]);
        }
    }

}
