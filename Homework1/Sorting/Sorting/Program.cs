using System;

namespace Sorting
{
    class Program
    {
        public static void BubleSort (int[] array)
        {
            for (var i = 0; i < array.Length - 1; ++i)
            {
                for (var j = 0; j < array.Length - 1 - i; ++j)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
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

            string[] nums = inputString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                try
                {
                    array[i] = int.Parse(nums[i]);
                }
                catch
                {
                    Console.WriteLine("Incorrect format of array elements");
                    return;
                }
            }

            BubleSort(array);

            Console.Write("Array after sorting: ");
            foreach (var i in array)
            {
                Console.Write($"{i} ");
            } 
        }
    }
}