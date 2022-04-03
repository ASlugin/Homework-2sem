namespace Sorting;

using System;

/// <summary>
/// Class containing BubbleSort and Main
/// </summary>
class Program
{
    /// <summary>
    /// Sorts an array using Bubble sort
    /// </summary>
    /// <param name="array">Array for sorting</param>
    public static void BubbleSort(int[] array)
    {
        for (var i = 0; i < array.Length - 1; ++i)
        {
            for (var j = 0; j < array.Length - 1 - i; ++j)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter the array elements: ");
        string? inputString = Console.ReadLine();
        if (inputString == null)
        {
            return;
        }

        var nums = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var array = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            if (!Int32.TryParse(nums[i], out array[i]))
            {
                Console.WriteLine("Incorrect format of array elements");
                return;
            }
        }

        BubbleSort(array);

        Console.Write("Array after sorting: ");
        foreach (var i in array)
        {
            Console.Write($"{i} ");
        } 
    }
}