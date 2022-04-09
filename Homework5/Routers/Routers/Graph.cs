namespace Routers;

class Graph
{
    public int[,] Matrix { get; private set; }

    private List<int> nodes;

    private Dictionary<(int, int), int> edges;

    private int sizeOfMatrix = 5;

    public Graph(string pathInputFile)
    {
        nodes = new();
        edges = new();
        Matrix = new int[sizeOfMatrix, sizeOfMatrix];
        Initialization(pathInputFile);
    }

    private void Initialization(string pathInputFile)
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
                throw new Exception("Incorrect input data");     //////////
            }

            if (!nodes.Contains(startNode))
            {
                nodes.Add(startNode);
            }

            string[] stringOfNodesSplitByComma = stringSplitByColon[1].Split(',');

            foreach (var node in stringOfNodesSplitByComma)
            {
                if (!int.TryParse(node.Split('(')[0].Replace(" ", ""), out int endNode)
                    || !int.TryParse(node.Split('(')[1].Replace(" ", "").Replace(")", ""), out int weight))
                {
                    throw new Exception("Incorrect input data");      //////////
                }

                while (endNode >= sizeOfMatrix || startNode >= sizeOfMatrix)
                {
                    Resize();
                }

                Matrix[startNode, endNode] = weight;
                Matrix[endNode, startNode] = weight;
                if (!nodes.Contains(endNode))
                {
                    nodes.Add(endNode);
                }

                if (edges.ContainsKey((startNode, endNode)) || edges.ContainsKey((endNode, startNode)))
                {
                    throw new Exception("Incorrect input data1"); ///////////////////
                }
                edges.Add((startNode, endNode), weight);

            }
        }
    }

    private void Resize()
    {
        sizeOfMatrix *= 2;
        var newMatrix = new int[sizeOfMatrix, sizeOfMatrix];
        for (int i = 0; i < sizeOfMatrix / 2; i++)
        {
            for (int j = 0; j < sizeOfMatrix / 2; j++)
            {
                newMatrix[i, j] = Matrix[i, j];
            }
        }
        Matrix = newMatrix;
    }

    public bool IsGraphConnectivity()
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

        for (int j = 0; j < sizeOfMatrix; ++j)
        {
            if (Matrix[startNode, j] > 0)
            {
                if (!visited[j])
                {
                    visitedNodes += DepthFirstSearch(j, ref visited);
                }
            }
        }
        return visitedNodes;
    }

    public void RemoveUnnecessaryEdges()
    {
        foreach (KeyValuePair<(int, int), int> edge in edges.OrderBy(key => key.Value))
        {
            var startNode = edge.Key.Item1;
            var endNode = edge.Key.Item2;

            Matrix[startNode, endNode] = 0;
            Matrix[endNode, startNode] = 0;

            if (IsGraphConnectivity())
            {
                edges.Remove(edge.Key);
            }
            else
            {
                Matrix[startNode, endNode] = edge.Value;
                Matrix[endNode, startNode] = edge.Value;
            }
        }
    }

    public void PrintGraph()
    {
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
                if (Matrix[i, j] > 0 && visitedEdge.ContainsKey((i, j)) && !visitedEdge[(i, j)])
                {
                    if (needToPrintStartNode)
                    {
                        Console.Write(i + ": ");
                        needToPrintStartNode = false;
                    }
                    if (needToPrintCommaBeforeNode)
                    {
                        Console.Write(", " + j + " (" + Matrix[i, j] + ")");
                    }
                    else
                    {
                        Console.Write(j + " (" + Matrix[i, j] + ")");
                        needToPrintCommaBeforeNode = true;
                    }
                    visitedEdge[(i, j)] = true;
                    visitedEdge[(j, i)] = true;
                }
            }
            if (!needToPrintStartNode)
            {
                Console.WriteLine();
            }
        }
    }

}
