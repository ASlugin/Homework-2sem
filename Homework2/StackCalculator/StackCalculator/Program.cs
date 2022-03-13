using System;
using Stack;

namespace StackCalculator
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter expression to calculate: ");
            var expression = Console.ReadLine();
            if (expression == null)
            {
                Console.WriteLine("String is null");
                return;
            }

            Console.Write("Enter type of stack (0 - on array, 1 - on list): ");
            int typeOfStack;
            if (!int.TryParse(Console.ReadLine(), out typeOfStack) || (typeOfStack != 0 && typeOfStack != 1))
            {
                Console.WriteLine("Incorrect type of stack!");
                return;
            }
            IStack stack = typeOfStack == 0 ? new StackOnArray() : new StackOnList();

            var result = Calculator.Calculate(expression, stack);
            Console.WriteLine(result == null ? "Something went wrong" : $"Result: {result}");
        }
    }
}