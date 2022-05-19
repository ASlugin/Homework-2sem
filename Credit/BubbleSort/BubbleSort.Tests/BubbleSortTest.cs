namespace BubbleSort.Tests;

using NUnit.Framework;
using System.Collections.Generic;

public class ComparerString : IComparer<string>
{
    int IComparer<string>.Compare(string? x, string? y)
    {
        return string.Compare(x, y);
    }
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

        Sort.BubbleSort(list, new ComparerString());

        Assert.AreEqual("a",list[0]);
        Assert.AreEqual("ab", list[1]);
        Assert.AreEqual("abc", list[2]);
        Assert.AreEqual("abcd", list[3]);
        Assert.AreEqual("abcde", list[4]);
    }

    [Test]
    public void BubbleSortOfPairsShallWorkCorreclty()
    {
        List<(int, int)> listOfPairs = new();
        listOfPairs.Add((9, 10));
        listOfPairs.Add((20, 5));
        listOfPairs.Add((30, 7));
        listOfPairs.Add((1, 2));

        Sort.BubbleSort(listOfPairs, new ComparerPairBySecondItems());

        Assert.AreEqual((1, 2),listOfPairs[0]);
        Assert.AreEqual((20, 5), listOfPairs[1]);
        Assert.AreEqual((30, 7), listOfPairs[2]);
        Assert.AreEqual((9, 10), listOfPairs[3]);
    }

    [Test]
    public void BubbleSortOfPairsDescendingOrderShallWorkCorreclty()
    {
        List<(int, int)> listOfPairs = new();
        listOfPairs.Add((9, 10));
        listOfPairs.Add((20, 5));
        listOfPairs.Add((30, 7));
        listOfPairs.Add((1, 2));

        Sort.BubbleSort(listOfPairs, new ComparerPairByFirstItemsDescendingOrder());
        
        Assert.AreEqual((30, 7), listOfPairs[0]);
        Assert.AreEqual((20, 5), listOfPairs[1]);
        Assert.AreEqual((9, 10), listOfPairs[2]);
        Assert.AreEqual((1, 2), listOfPairs[3]);
    }

}
