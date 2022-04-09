namespace Routers;

static class RoutersUtility
{
    public static bool GenerateConfiguration(string pathToInputFile, string pathToOutputFile)
    {
        try
        {
            var graph = new Graph(pathToInputFile);
            if (!graph.IsGraphConnectivity())
            {
                Console.Error.WriteLine("The graph is not connectivity");
                return false;
            }
            graph.RemoveUnnecessaryEdges();
            graph.PrintGraphToFile(pathToOutputFile);
            return true;
        }
        catch(InvalidDataException)
        {
            Console.Error.WriteLine("Invalid input data");
            return false;
        }
        catch (RepeatedDeclaringEdgeException exc)
        {
            Console.Error.WriteLine(exc.Message);
            return false;
        }
        
    }
}
