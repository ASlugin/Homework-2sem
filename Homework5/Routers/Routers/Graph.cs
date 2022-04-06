namespace Routers;

class Graph
{
    public int[,] Matrix { get; private set; }

    private List<int> nodes;

    private int sizeOfMatrix = 5;

    public Graph(string pathInputFile)
    {
        nodes = new();
        Matrix = new int[sizeOfMatrix, sizeOfMatrix];
        Initialization(pathInputFile);
    }

    private void Initialization(string pathInputFile)
    {

        using (StreamReader inputFile = new StreamReader(pathInputFile))
        {
            while (!inputFile.EndOfStream)
            {
                string? line = inputFile.ReadLine();
                if (line == null)
                {
                    break;
                }

                string[] stringSplitByColon = line.Split(':');
                int startNode;
                if (stringSplitByColon.Length < 2 || !int.TryParse(stringSplitByColon[0], out startNode))
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
                    int finishNode = 0;
                    int weight = 0;
                    if (!int.TryParse(node.Split('(')[0].Replace(" ", ""), out finishNode) || !int.TryParse(node.Split('(')[1].Replace(" ", "").Replace(")", ""), out weight))
                    {
                        throw new Exception("Incorrect input data");      //////////
                    }

                    while (finishNode >= sizeOfMatrix || startNode >= sizeOfMatrix)
                    {
                        Resize();
                    }

                    Matrix[startNode, finishNode] = weight;
                    Matrix[finishNode, startNode] = weight;
                    if (!nodes.Contains(finishNode))
                    {
                        nodes.Add(finishNode);
                    }
                }
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


}
