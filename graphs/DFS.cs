using System;
using System.Collections.Generic;

class DFS
{
    private Dictionary<int, List<int>> graph;

    public DFS()
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

    // Recursive DFS
    public void RecursiveTraverse(int start)
    {
        HashSet<int> visited = new HashSet<int>();
        RecursiveDFS(start, visited);
    }

    private void RecursiveDFS(int vertex, HashSet<int> visited)
    {
        if (visited.Contains(vertex))
            return;

        Console.Write(vertex + " ");
        visited.Add(vertex);

        if (graph.ContainsKey(vertex))
        {
            foreach (int neighbor in graph[vertex])
            {
                RecursiveDFS(neighbor, visited);
            }
        }
    }

    // Iterative DFS
    public void IterativeTraverse(int start)
    {
        HashSet<int> visited = new HashSet<int>();
        Stack<int> stack = new Stack<int>();
        stack.Push(start);

        while (stack.Count > 0)
        {
            int vertex = stack.Pop();
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
                            stack.Push(neighbor);
                        }
                    }
                }
            }
        }
    }
}
