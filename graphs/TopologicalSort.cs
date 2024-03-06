using System;
using System.Collections.Generic;

public class TopologicalSort
{
    private Graph _graph;
    private Stack<int> _stack;
    private HashSet<int> _visited;

    public TopologicalSort(Graph graph)
    {
        _graph = graph;
        _stack = new Stack<int>();
        _visited = new HashSet<int>();
    }

    public List<int> Sort()
    {
        foreach (var vertex in _graph.GetAdjacencyList().Keys)
        {
            if (!_visited.Contains(vertex))
                DFS(vertex);
        }

        var result = new List<int>(_stack);
        return result;
    }

    private void DFS(int vertex)
    {
        _visited.Add(vertex);

        if (_graph.GetAdjacencyList().ContainsKey(vertex))
        {
            foreach (var neighbor in _graph.GetAdjacencyList()[vertex].Keys)
            {
                if (!_visited.Contains(neighbor))
                    DFS(neighbor);
            }
        }

        _stack.Push(vertex);
    }
}
