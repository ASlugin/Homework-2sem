using System;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = Console.ReadLine();
            if (inputString == null)
            {
                return;
            }
            string[] nums = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] inputArray = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                inputArray[i] = int.Parse(nums[i]);
            }

            foreach (var i in inputArray)
            {
                Console.WriteLine(i);
            }
        }
    }
}