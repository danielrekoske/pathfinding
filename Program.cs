class Program
{
    static void Main(string[] args)
    {
        // Generate a graph
        Graph graph = Graph.GenerateGraph(6, 8);
        graph.PrintGraph();

        // Perform Floyd-Warshall algorithm
        FloydWarshall floydWarshall = new FloydWarshall(graph);
        floydWarshall.FindShortestPaths();
        floydWarshall.PrintShortestPaths();
    }
}
