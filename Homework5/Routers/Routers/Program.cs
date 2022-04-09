namespace Routers;
class Program
{
    private static int Main(string[] args)
    {
        Console.Write("Enter path to input file: ");
        var pathToInputFile = Console.ReadLine();
        Console.Write("Enter path to output file: ");
        var pathToOutputFile = Console.ReadLine();
        if (pathToInputFile == null || pathToOutputFile == null)
        {
            return -1;
        }
        if (!RoutersUtility.GenerateConfiguration(pathToInputFile, pathToOutputFile))
        {
            return -1;
        }
        Console.WriteLine("Configuration was generated successfully");
        return 0;
    }
}