namespace Routers;

/// <summary>
/// Class for graph and methods for work with it
/// </summary>
public class Graph
{
    private int[,] matrix;
    private List<int> nodes;
    private Dictionary<(int, int), int> edges;

    public Graph(string pathInputFile)
    {
        nodes = new();
        edges = new();
        matrix = new int[5, 5];
        Initialize(pathInputFile);
    }

    private void Initialize(string pathInputFile)
    {
        using StreamReader inputFile = new(pathInputFile);
        while (!inputFile.EndOfStream)
        {
            string? line = inputFile.ReadLine();
            if (line == null)
            {
                break;
            }

            string[] stringSplitByColon = line.Split(':');
            if (stringSplitByColon.Length < 2 || !int.TryParse(stringSplitByColon[0], out int startNode))
            {
                throw new InvalidDataException();
            }

            if (!nodes.Contains(startNode))
            {
                nodes.Add(startNode);
            }

            string[] stringOfNodesSplitByCloseBracket = stringSplitByColon[1].Replace(",", "").Replace(" ", "").Split(')');
            if (stringOfNodesSplitByCloseBracket.Length < 2)
            {
                throw new InvalidDataException();
            }
            foreach (var node in stringOfNodesSplitByCloseBracket)
            {
                if (string.Compare(node, "") == 0)
                {
                    continue;
                }
                if (node.Split('(').Length < 2)
                {
                    throw new InvalidDataException();
                }
                if (!int.TryParse(node.Split('(')[0], out int endNode)
                    || !int.TryParse(node.Split('(')[1], out int weight))
                {
                    throw new InvalidDataException();
                }

                while (endNode >= matrix.GetLength(0) || startNode >= matrix.GetLength(0))
                {
                    Resize();
                }

                matrix[startNode, endNode] = weight;
                matrix[endNode, startNode] = weight;
                if (!nodes.Contains(endNode))
                {
                    nodes.Add(endNode);
                }

                if (edges.ContainsKey((startNode, endNode)) || edges.ContainsKey((endNode, startNode)))
                {
                    throw new RepeatedDeclaringEdgeException("Repeated declaring a edge");
                }
                edges.Add((startNode, endNode), weight);
            }
        }
    }

    private void Resize()
    {
        var newSize = matrix.GetLength(0) * 2;
        var newMatrix = new int[newSize, newSize];
        for (int i = 0; i < newSize / 2; i++)
        {
            for (int j = 0; j < newSize / 2; j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }
        matrix = newMatrix;
    }

    /// <summary>
    /// Check whether graph is connectivity
    /// </summary>
    /// <returns>Returns true if graph is connectivity, else returns false</returns>
    public bool IsGraphConnected()
    {
        var visited = new Dictionary<int, bool>();
        foreach (var node in nodes)
        {
            visited.Add(node, false);
        }
        var minNode = nodes.Min();
        return nodes.Count == DepthFirstSearch(minNode, ref visited);
    }

    private int DepthFirstSearch (int startNode, ref Dictionary<int, bool> visited)
    {
        int visitedNodes = 1;
        visited[startNode] = true;
        for (int j = nodes.Min(); j <= nodes.Max(); ++j)
        {
            if (matrix[startNode, j] > 0)
            {
                if (!visited[j])
                {
                    visitedNodes += DepthFirstSearch(j, ref visited);
                }
            }
        }
        return visitedNodes;
    }

    /// <summary>
    /// Delete all edges so that graph remains connectivity
    /// </summary>
    public void RemoveUnnecessaryEdges()
    {
        foreach (KeyValuePair<(int, int), int> edge in edges.OrderBy(key => key.Value))
        {
            var startNode = edge.Key.Item1;
            var endNode = edge.Key.Item2;

            matrix[startNode, endNode] = 0;
            matrix[endNode, startNode] = 0;

            if (IsGraphConnected())
            {
                edges.Remove(edge.Key);
            }
            else
            {
                matrix[startNode, endNode] = edge.Value;
                matrix[endNode, startNode] = edge.Value;
            }
        }
    }

    /// <summary>
    /// Creates file on specified path and writes graph there
    /// </summary>
    /// <param name="pathToOutputFile">Path to output file</param>
    public void PrintGraphToFile(string pathToOutputFile)
    {
        FileStream outputFile = File.Create(pathToOutputFile);
        using StreamWriter output = new StreamWriter(outputFile);

        var visitedEdge = new Dictionary<(int, int), bool>();
        foreach (var edge in edges)
        {
            visitedEdge.Add((edge.Key.Item1, edge.Key.Item2), false);
            visitedEdge.Add((edge.Key.Item2, edge.Key.Item1), false);
        }

        for (int i = nodes.Min(); i <= nodes.Max(); ++i)
        {
            bool needToPrintStartNode = true;
            bool needToPrintCommaBeforeNode = false;
            for (int j = nodes.Min(); j <= nodes.Max(); ++j)
            {
                if (matrix[i, j] > 0 && visitedEdge.ContainsKey((i, j)) && !visitedEdge[(i, j)])
                {
                    if (needToPrintStartNode)
                    {
                        output.Write($"{i}: ");
                        needToPrintStartNode = false;
                    }
                    if (needToPrintCommaBeforeNode)
                    {
                        output.Write($", {j} ({matrix[i, j]})");
                    }
                    else
                    {
                        output.Write($"{j} ({matrix[i, j]})");
                        needToPrintCommaBeforeNode = true;
                    }
                    visitedEdge[(i, j)] = true;
                    visitedEdge[(j, i)] = true;
                }
            }
            if (!needToPrintStartNode)
            {
                output.WriteLine();
            }
        }
    }
}
