namespace BWT;

using System;

class Program
{ 
    public static void Main(string[] args)
    {
        Console.Write("Enter a string for Burrows-Wheeler tranformation: ");
        var inputString = Console.ReadLine();
        if (inputString == null)
        {
            return;
        }

        var resultBWT = BurrowsWheelerTransform.DirectBWT(inputString);
        Console.WriteLine($"String after Burrows-Wheeler transformation: {resultBWT.Item1}");
        Console.WriteLine($"Position of the end of source string in string after BWT: {resultBWT.Item2}");

        string stringAfterReverseBWT = BurrowsWheelerTransform.ReverseBWT(resultBWT);
        Console.WriteLine($"String after reverse Burrows-Wheeler transformation: {stringAfterReverseBWT}");

        if (string.Compare(stringAfterReverseBWT, inputString) == 0)
        {
            Console.WriteLine("Burrows-Wheeler transformation was performed correctly");
        }
        else
        {
            Console.WriteLine("Burrows-Wheeler transformation was performed incorrectly");
        }
    }
}