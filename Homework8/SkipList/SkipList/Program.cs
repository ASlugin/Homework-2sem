namespace SkipList;

class Program
{
    private static void Main(string[] args)
    {
        SkipList<int> a = new();

        a.Add(13);
        a.Add(7);
        a.Add(3);
        a.Add(14);
        a.Add(17);
        a.Add(12);
        a.Add(4);
        a.Add(2);
        a.Add(2);

        foreach (var item in a)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        foreach (var item in a)
        {
            Console.Write(item + " ");
            a.Add(11);
        }
        Console.WriteLine();
        foreach (var item in a)
        {
            Console.Write(item + " ");
        }
    }
}
