namespace SkipList;

class Program
{
    private static void Main(string[] args)
    {
        SkipList<int> a = new();

        a.Add(13);
        a.Add(7);
        a.Add(3);
        a.Add(7);
        a.Add(7);
        a.Add(7);
        a.Add(4);

        a.RemoveAt(2);
    }
}
