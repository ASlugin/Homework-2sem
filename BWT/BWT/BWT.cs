namespace BWT;

using System;
using System.Collections.Generic;

/// <summary>
/// Class is contained method for perfoming direct and reverse Burrows Wheeler Transformation
/// </summary>
public static class BurrowsWheelerTransform
{
    /// <summary>
    /// Performs a direct Burrows-Wheeler transformation 
    /// </summary>
    /// <param name="input">The source string to be converted</param>
    /// <returns>Tuple with result string and position of the end source string</returns>
    public static (string, int) DirectBWT(string input)
    {
        var array = SortArraySuffix(input);
        string resultString = "";
        int positionOfEnd = -1;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == 0)
            {
                positionOfEnd = i;
                resultString += input[input.Length - 1];
            }
            else
            {
                resultString += input[array[i] - 1];
            }
        }
        return (resultString, positionOfEnd);
    }

    private static int[] SortArraySuffix(string input)
    {
        var array = new int[input.Length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }
        for (var i = 0; i < input.Length; i++)
        {
            for (var j = 0; j < input.Length - i - 1; j++)
            {
                if (CompareSuffixes(input, array[j], array[j + 1]) > 0)
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
        return array;
    }

    private static int CompareSuffixes(string input, int positionFirst, int positionSecond)
    {
        for (int i = 0; i < input.Length - Math.Max(positionFirst, positionSecond); i++)
        {
            var resultComparing = input[positionFirst + i].CompareTo(input[positionSecond + i]);
            if (resultComparing > 0)
            {
                return 1;
            }
            else if (resultComparing < 0)
            {
                return -1;
            }
        }
        if (positionFirst == positionSecond)
        {
            return 0;
        }
        return positionFirst < positionSecond ? 1 : -1;
    }

    /// <summary>
    /// Performs a reverse Burrows-Wheeler transformation
    /// </summary>
    public static string ReverseBWT((string, int) stringAndPositionForReverseBWT)
    {
        List<(char, int)> listOfChars = new();
        char[] charsOfString = stringAndPositionForReverseBWT.Item1.ToCharArray();
        Array.Sort(charsOfString);
        for (int i = 0; i < charsOfString.Length; i++)
        {
            listOfChars.Add((charsOfString[i], i));
        }

        int[] positions = new int[stringAndPositionForReverseBWT.Item1.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            int j = 0;
            var currentChar = listOfChars[j];
            while (stringAndPositionForReverseBWT.Item1[i] != currentChar.Item1)
            {
                j++;
                currentChar = listOfChars[j];
            }
            positions[i] = currentChar.Item2;
            listOfChars.RemoveAt(j);
        }

        string inverseToResult = "";
        var positionSymbol = stringAndPositionForReverseBWT.Item2;
        for (int i = 0; i < stringAndPositionForReverseBWT.Item1.Length; i++)
        {
            inverseToResult += stringAndPositionForReverseBWT.Item1[positionSymbol];
            positionSymbol = positions[positionSymbol];
        }
        return new string(inverseToResult.Reverse().ToArray());
    }
}