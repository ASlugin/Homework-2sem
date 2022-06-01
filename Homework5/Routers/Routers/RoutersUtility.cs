namespace Routers;

/// <summary>
/// Class for utility which let to generate configuration for routers
/// </summary>
static class RoutersUtility
{
    /// <summary>
    /// Generates configuration of routers so that they are connected
    /// </summary>
    /// <param name="pathToInputFile">Path to file with initial graph</param>
    /// <param name="pathToOutputFile">Path to file to put resulting graph</param>
    /// <returns>Returns false if initial graph was not connectivity or input data was invalid, else returns true</returns>
    public static bool GenerateConfiguration(string pathToInputFile, string pathToOutputFile)
    {
        try
        {
            var graph = new Graph(pathToInputFile);
            if (!graph.IsGraphConnected())
            {
                Console.Error.WriteLine("The graph is not connected");
                return false;
            }
            graph.RemoveUnnecessaryEdges();
            graph.PrintGraphToFile(pathToOutputFile);
            return true;
        }
        catch (InvalidDataException)
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
