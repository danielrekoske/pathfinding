using System;
using System.Collections.Generic;

public class FloydWarshall
{
    private Graph _graph;
    private int[,] _distances;

    public FloydWarshall(Graph graph)
    {
        _graph = graph;
        int numVertices = _graph.GetAdjacencyList().Count;
        _distances = new int[numVertices, numVertices];
    }

    public void FindShortestPaths()
    {
        // Initialize distances array with direct edge weights
        foreach (var vertex in _graph.GetAdjacencyList())
        {
            foreach (var neighbor in vertex.Value)
            {
                _distances[vertex.Key, neighbor.Key] = neighbor.Value;
            }
        }

        // Initialize distances array with infinity where no direct edge exists
        for (int i = 0; i < _distances.GetLength(0); i++)
        {
            for (int j = 0; j < _distances.GetLength(1); j++)
            {
                if (i != j && _distances[i, j] == 0)
                {
                    _distances[i, j] = int.MaxValue;
                }
            }
        }

        // Floyd-Warshall algorithm
        int numVertices = _distances.GetLength(0);
        for (int k = 0; k < numVertices; k++)
        {
            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    if (_distances[i, k] != int.MaxValue && _distances[k, j] != int.MaxValue &&
                        _distances[i, k] + _distances[k, j] < _distances[i, j])
                    {
                        _distances[i, j] = _distances[i, k] + _distances[k, j];
                    }
                }
            }
        }
    }

    public void PrintShortestPaths()
    {
        Console.WriteLine("Shortest paths between all pairs of vertices:");
        for (int i = 0; i < _distances.GetLength(0); i++)
        {
            for (int j = 0; j < _distances.GetLength(1); j++)
            {
                if (_distances[i, j] == int.MaxValue)
                {
                    Console.Write("INF\t");
                }
                else
                {
                    Console.Write($"{_distances[i, j]}\t");
                }
            }
            Console.WriteLine();
        }
    }
}
