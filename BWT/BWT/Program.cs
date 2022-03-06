using System;

namespace BWT
{
    class Program
    {
        /// <summary>
        /// Performs a direct Burrows-Wheeler transformation
        /// </summary>
        /// <param name="input">The source string to be converted</param>
        /// <param name="positionOfEnd">Takes control and puts in it position of the end of input string in resulting string</param>
        /// <returns></returns>
        public static string DirectBWT(string input, ref int positionOfEnd)
        {
            positionOfEnd = 0;
            char[] resultChar = new char[input.Length];
            int[] startPositionString = new int[input.Length];
            
            input += input;
            
            for (int i = 1; i <= input.Length / 2; i++)
            {
                resultChar[i - 1] = input[i + input.Length / 2 - 1];
                startPositionString[i - 1] = i;
                if (i > 1)
                {
                    int j = i - 1;
                    while (j > 0 && string.Compare(input.Substring(startPositionString[j], input.Length / 2), input.Substring(startPositionString[j - 1], input.Length / 2)) < 0)
                    {
                        char tempChar = resultChar[j];
                        resultChar[j] = resultChar[j - 1];
                        resultChar[j - 1] = tempChar;

                        int temp = startPositionString[j];
                        startPositionString[j] = startPositionString[j - 1];
                        startPositionString[j - 1] = temp;

                        j--;
                    }

                    if (i == input.Length / 2)
                    {
                        positionOfEnd = j;
                    }
                }
            }

            string result = String.Concat(resultChar);
            return result;
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter a string for Burrows-Wheeler tranformation: ");
            var inputString = Console.ReadLine();
            if (inputString == null)
                return;

            int positionOfEnd = 0;
            string stringAfterBWT = DirectBWT(inputString, ref positionOfEnd);
            Console.Write("String after Burrows-Wheeler transformation: ");
            Console.WriteLine(stringAfterBWT);
            Console.Write("Position of the end of source string in string after BWT: ");
            Console.WriteLine(positionOfEnd);
            
        }
    }
}