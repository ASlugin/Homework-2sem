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

        public static void sortArrayChar(char[] inputString)
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                for (int j = 0; j < inputString.Length - i - 1; j++)
                {
                    if (inputString[j] > inputString[j + 1])
                    {
                        char temp = inputString[j];
                        inputString[j] = inputString[j + 1];
                        inputString[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Performs a reverse Burrows-Wheeler transformation
        /// </summary>
        /// <param name="input">String that was converted by burrows-wheeler transformation</param>
        /// <param name="positionOfEnd">Position of the end of source string in string</param>
        /// <returns></returns>
        public static string ReverseBWT(string input, int positionOfEnd)
        {
            char sybmolNotFromString = (char)1;
            while (input.Contains(sybmolNotFromString))
            {
                sybmolNotFromString++;
            }

            char[] charsOfString = input.ToCharArray();
            sortArrayChar(charsOfString);
            string stringAfterSort = string.Concat(charsOfString);

            int[] indexOfNextSymbol = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                indexOfNextSymbol[i] = stringAfterSort.IndexOf(input[i]);
                stringAfterSort = stringAfterSort.Remove(indexOfNextSymbol[i], 1);
                stringAfterSort = stringAfterSort.Insert(indexOfNextSymbol[i], sybmolNotFromString.ToString());
            }

            string inverseToResult = input[positionOfEnd].ToString();
            int j = indexOfNextSymbol[positionOfEnd];
            while (inverseToResult.Length < input.Length)
            {
                inverseToResult = inverseToResult + input[j];
                j = indexOfNextSymbol[j];
            }

            return String.Concat(inverseToResult.ToCharArray().Reverse());
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter a string for Burrows-Wheeler tranformation: ");
            var inputString = Console.ReadLine();
            if (inputString == null)
            {
                return;
            }

            int positionOfEnd = 0;
            string stringAfterBWT = DirectBWT(inputString, ref positionOfEnd);
            Console.WriteLine($"String after Burrows-Wheeler transformation: {stringAfterBWT}");
            Console.WriteLine($"Position of the end of source string in string after BWT: {positionOfEnd}");
            

            string stringAfterReverseBWT = ReverseBWT(stringAfterBWT, positionOfEnd);
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
}