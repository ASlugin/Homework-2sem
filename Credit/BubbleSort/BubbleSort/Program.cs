namespace BubbleSort;

/// <summary>
/// Class that contains method Compare for comparing integer value
/// </summary>
public class ComparerInt : IComparer<int>
{
    int IComparer<int>.Compare(int x, int y)
    {
        if (x == y)
        {
            return 0;
        }
        return x > y ? 1 : -1;
    }
}

/// <summary>
/// Class that contains method Compare for comparing integer value in descending order
/// </summary>
public class ComparerIntDescendingOrder : IComparer<int>
{
    int IComparer<int>.Compare(int x, int y)
    {
        if (x == y)
        {
            return 0;
        }
        return x > y ? -1 : 1;
    }
}

public class Program
{
    private static void Main(string[] args)
    {
        List<int> list = new();

        list.Add(50);
        list.Add(2);
        list.Add(1);
        list.Add(120);
        list.Add(70);

        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        Sort.BubbleSort<int>(list, new ComparerInt());
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        Sort.BubbleSort<int>(list, new ComparerIntDescendingOrder());
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
    }
}