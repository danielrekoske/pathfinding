public class BellmanFord
{
    private Graph _graph;
    private int[] _distances;
    private int[] _predecessors;

    public BellmanFord(Graph graph)
    {
        _graph = graph;
        _distances = new int[_graph.GetAdjacencyList().Count];
        _predecessors = new int[_graph.GetAdjacencyList().Count];
    }

    public bool FindShortestPaths(int source)
    {
        // Initialize distances and predecessors
        for (int i = 0; i < _distances.Length; i++)
        {
            _distances[i] = int.MaxValue;
            _predecessors[i] = -1;
        }
        _distances[source] = 0;

        // Relax edges repeatedly
        for (int i = 0; i < _graph.GetAdjacencyList().Count - 1; i++)
        {
            foreach (var vertex in _graph.GetAdjacencyList())
            {
                foreach (var neighbor in vertex.Value)
                {
                    if (_distances[vertex.Key] != int.MaxValue && _distances[vertex.Key] + neighbor.Value < _distances[neighbor.Key])
                    {
                        _distances[neighbor.Key] = _distances[vertex.Key] + neighbor.Value;
                        _predecessors[neighbor.Key] = vertex.Key;
                    }
                }
            }
        }

        // Check for negative cycles
        foreach (var vertex in _graph.GetAdjacencyList())
        {
            foreach (var neighbor in vertex.Value)
            {
                if (_distances[vertex.Key] != int.MaxValue && _distances[vertex.Key] + neighbor.Value < _distances[neighbor.Key])
                {
                    return false; // Negative cycle detected
                }
            }
        }

        return true;
    }

    public List<int> GetShortestPath(int destination)
    {
        List<int> path = new List<int>();

        if (_distances[destination] == int.MaxValue)
            return path; // No path exists

        int currentVertex = destination;
        while (currentVertex != -1)
        {
            path.Add(currentVertex);
            currentVertex = _predecessors[currentVertex];
        }
        path.Reverse();
        return path;
    }

    public void PrintShortestPaths()
    {
        Console.WriteLine("Vertex\tDistance\tPath");
        for (int i = 0; i < _distances.Length; i++)
        {
            Console.Write($"{i}\t{_distances[i]}\t\t");
            List<int> path = GetShortestPath(i);
            foreach (int vertex in path)
            {
                Console.Write(vertex + " ");
            }
            Console.WriteLine();
        }
    }
}
