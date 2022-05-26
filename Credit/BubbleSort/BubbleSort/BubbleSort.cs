namespace BubbleSort;

using System.Collections.Generic;

/// <summary>
/// Class for generic method BubbleSort
/// </summary>
public static class Sort
{
    /// <summary>
    /// Sorts list by bubble sorting
    /// </summary>
    /// <param name="inputList"></param>
    /// <param name="comparator">Object that implements method Compare</param>
    public static void BubbleSort<T>(IList<T> inputList, IComparer<T> comparator)
    {
        for (int i = 0; i < inputList.Count - 1; ++i)
        {
            for (int j = 0; j < inputList.Count - 1 - i; ++j)
            {
                if (comparator.Compare(inputList[j], inputList[j + 1]) > 0)
                {
                    var temp = inputList[j];
                    (inputList[j], inputList[j + 1]) = (inputList[j + 1], inputList[j]);
                }
            }
        }
    }
}
