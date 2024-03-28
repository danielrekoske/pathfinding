class BFS
{
    private Dictionary<int, List<int>> graph;

    public BFS()
    {
        graph = new Dictionary<int, List<int>>();
    }

    public void AddEdge(int u, int v)
    {
        if (!graph.ContainsKey(u))
        {
            graph[u] = new List<int>();
        }
        graph[u].Add(v);
    }

    public void Traverse(int start)
    {
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int vertex = queue.Dequeue();
            if (!visited.Contains(vertex))
            {
                Console.Write(vertex + " ");
                visited.Add(vertex);
                if (graph.ContainsKey(vertex))
                {
                    foreach (int neighbor in graph[vertex])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }
        }
    }
}
