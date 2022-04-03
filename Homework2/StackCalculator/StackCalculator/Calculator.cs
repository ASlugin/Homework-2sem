namespace StackCalculator;

using Stack;

public class Calculator
{
    private static bool IsOperation(string element)
    {
        return element.Length == 1 && (element[0] == '+' || element[0] == '-' || element[0] == '*' || element[0] == '/');
    }

    /// <summary>
    /// Calculates expression in Reverse Polish notation
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="stack"></param>
    /// <returns>Calculation result or null, if error has occurred</returns>
    public static double? Calculate(string expression, IStack stack)
    {

        var expressionSplit = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string element in expressionSplit)
        {
            int number;
            if (int.TryParse(element, out number))
            {
                stack.Push(number);
            }
            else if (IsOperation(element))
            {
                var secondNumber = stack.Pop();
                var firstNumber = stack.Pop();
                if (firstNumber == null || secondNumber == null)
                {
                    return null;
                }
                switch (element)
                {
                    case "+":
                        stack.Push((double)firstNumber + (double)secondNumber);
                        break;
                    case "-":
                        stack.Push((double)firstNumber - (double)secondNumber);
                        break;
                    case "*":
                        stack.Push((double)firstNumber * (double)secondNumber);
                        break;
                    case "/":
                        if (Math.Abs((double)secondNumber) < double.Epsilon)
                        {
                            return null;
                        }
                        stack.Push((double)firstNumber / (double)secondNumber);
                        break;
                }
            }
            else
            {
                return null;
            }
        }

        var result = stack.Pop();
        if (result == null || !stack.IsEmpty())
        {
            return null;
        }
        return result;
    }
}
