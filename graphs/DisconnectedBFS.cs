class DisconnectedBFS
{
    private int V; // Number of vertices
    private List<int>[] adj; // Adjacency list representation of the graph

    public DisconnectedBFS(int vertices)
    {
        V = vertices;
        adj = new List<int>[V];
        for (int i = 0; i < V; ++i)
        {
            adj[i] = new List<int>();
        }
    }

    // Function to add an edge into the graph
    public void AddEdge(int v, int w)
    {
        adj[v].Add(w); // Add w to v's list
        adj[w].Add(v); // Add v to w's list (assuming undirected graph)
    }

    // Breadth-first search traversal from a given source vertex
    private void BFSUtil(int s, bool[] visited)
    {
        // Create a queue for BFS
        Queue<int> queue = new Queue<int>();

        // Mark the current node as visited and enqueue it
        visited[s] = true;
        queue.Enqueue(s);

        while (queue.Count != 0)
        {
            // Dequeue a vertex from queue and print it
            s = queue.Dequeue();
            Console.Write(s + " ");

            // Get all adjacent vertices of the dequeued vertex s. If an adjacent has not been visited, then mark it visited and enqueue it
            foreach (int i in adj[s])
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }
    }

    // Function to perform BFS traversal for disconnected graphs
    public void BFS()
    {
        bool[] visited = new bool[V];

        // Mark all the vertices as not visited
        for (int i = 0; i < V; ++i)
        {
            if (!visited[i])
            {
                BFSUtil(i, visited);
            }
        }
    }
}
