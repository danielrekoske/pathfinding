public class DFSCycle
{
    private List<int>[] adjacencyList;
    private bool[] visited;
    private bool[] inStack;

    // Constructor initializes the cycle detector with the number of vertices
    public DFSCycle(int numVertices)
    {
        adjacencyList = new List<int>[numVertices];
        visited = new bool[numVertices];
        inStack = new bool[numVertices];

        for (int i = 0; i < numVertices; i++)
        {
            adjacencyList[i] = new List<int>();
        }
    }

    // Method to add a directed edge from vertex u to vertex v
    public void AddEdge(int u, int v)
    {
        adjacencyList[u].Add(v);
    }

    // Method to perform Depth-First Search for cycle detection
    private bool HasCycleUtil(int vertex)
    {
        visited[vertex] = true;
        inStack[vertex] = true;

        foreach (int neighbor in adjacencyList[vertex])
        {
            if (!visited[neighbor])
            {
                if (HasCycleUtil(neighbor))
                    return true;
            }
            else if (inStack[neighbor])
            {
                return true; // Cycle detected
            }
        }

        inStack[vertex] = false;
        return false;
    }

    // Method to detect cycles in the graph
    public bool HasCycle()
    {
        int numVertices = adjacencyList.Length;

        for (int i = 0; i < numVertices; i++)
        {
            if (!visited[i] && HasCycleUtil(i))
                return true;
        }

        return false;
    }
}
