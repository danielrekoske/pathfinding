public class DFSUndirectedCycle
{
    private List<int>[] adjacencyList;
    private bool[] visited;

    // Constructor initializes the cycle detector with the number of vertices
    public DFSUndirectedCycle(int numVertices)
    {
        adjacencyList = new List<int>[numVertices];
        visited = new bool[numVertices];

        for (int i = 0; i < numVertices; i++)
        {
            adjacencyList[i] = new List<int>();
        }
    }

    // Method to add an undirected edge between vertex u and vertex v
    public void AddEdge(int u, int v)
    {
        adjacencyList[u].Add(v);
        adjacencyList[v].Add(u); // Undirected graph
    }

    // Method to perform Depth-First Search for cycle detection
    private bool HasCycleUtil(int vertex, int parent)
    {
        visited[vertex] = true;

        foreach (int neighbor in adjacencyList[vertex])
        {
            if (!visited[neighbor])
            {
                if (HasCycleUtil(neighbor, vertex))
                    return true;
            }
            else if (neighbor != parent)
            {
                return true; // Cycle detected
            }
        }

        return false;
    }

    // Method to detect cycles in the graph
    public bool HasCycle()
    {
        int numVertices = adjacencyList.Length;

        for (int i = 0; i < numVertices; i++)
        {
            if (!visited[i] && HasCycleUtil(i, -1))
                return true;
        }

        return false;
    }
}
