namespace MapFilterFold;

public class Functions
{
    /// <summary>
    /// Creates new list of elements from source list applying the function to all elements
    /// </summary>
    /// <typeparam name="T">Type of elements of source list</typeparam>
    /// <typeparam name="TOutput">Type of elemets of resulting list</typeparam>
    /// <param name="list">Source list</param>
    /// <param name="function">Function that changes element of list</param>
    /// <returns>New resulting list</returns>
    public static List<TOutput> Map<T, TOutput>(List<T> list, Func<T, TOutput> function)
    {
        List<TOutput> result = new();
        foreach (var item in list)
        {
            result.Add(function(item));
        }
        return result;
    }

    /// <summary>
    /// Creates new list of elements from source list for which function returned true
    /// </summary>
    /// <typeparam name="T">Type of elemets of list</typeparam>
    /// <param name="list">Source list</param>
    /// <param name="function">Function that return true or false depending on the element</param>
    /// <returns>New resulting list</returns>
    public static List<T> Filter<T>(List<T> list, Func<T, bool> function)
    {
        List<T> result = new();
        foreach (var item in list)
        {
            if (function(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    /// <summary>
    /// Accumulates value
    /// </summary>
    /// <typeparam name="T">Type of elemets of list</typeparam>
    /// <typeparam name="TValue">Type of initial and accumulated value</typeparam>
    /// <param name="list">Source list</param>
    /// <param name="initValue">Initial value</param>
    /// <param name="function">Function that returns new accumulated value depending on old accumulated value and current element of list</param>
    /// <returns>Returns accumulated value</returns>
    public static TValue Fold<T, TValue>(List<T> list, TValue initValue, Func<TValue, T, TValue> function)
    {
        TValue accum = initValue;
        foreach(var item in list)
        {
            accum = function(accum, item);
        }
        return accum;
    }

    private static void Main(string[] args)
    {
        var list = new List<int>() { 1, 2, 3 };

        var listAfterMap = Map(list, x => { var a = x * 2; return a * 10; });
        foreach(var item in listAfterMap)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        var listAfteFilter = Filter(list, x => (x % 2 == 0));
        foreach (var item in listAfteFilter)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        var listAfterFold = Fold(list, 1, (acc, elem) => acc * elem);
        Console.WriteLine(listAfterFold);
    }
}
