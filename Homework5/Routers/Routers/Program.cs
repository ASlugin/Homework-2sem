namespace Routers;
class Program
{
    private static void Main(string[] args)
    {

        var a = new Graph("../../../Input.txt");
        Console.WriteLine(a.IsGraphConnectivity() ? "Graph is connectivity" : "Graph is not connectivity");

    }
}