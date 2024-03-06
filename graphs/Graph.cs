using System;
using System.Collections.Generic;

// Directed graph class
public class Graph
{
    private Dictionary<int, Dictionary<int, int>> _adjacencyList;

    public Graph()
    {
        _adjacencyList = new Dictionary<int, Dictionary<int, int>>();
    }

    public void AddVertex(int vertex)
    {
        if (!_adjacencyList.ContainsKey(vertex))
            _adjacencyList[vertex] = new Dictionary<int, int>();
    }

    public void AddEdge(int source, int destination, int weight)
    {
        AddVertex(source);
        AddVertex(destination);
        _adjacencyList[source][destination] = weight;
    }

    public Dictionary<int, Dictionary<int, int>> GetAdjacencyList()
    {
        return _adjacencyList;
    }

    public void PrintGraph()
    {
        foreach (var vertex in _adjacencyList)
        {
            Console.Write($"Vertex {vertex.Key}: ");
            foreach (var edge in vertex.Value)
            {
                Console.Write($"({edge.Key}, {edge.Value}) ");
            }
            Console.WriteLine();
        }
    }

    public static Graph GenerateGraph(int numVertices, int numEdges)
    {
        var random = new Random();
        var graph = new Graph();

        for (int i = 0; i < numVertices; i++)
        {
            graph.AddVertex(i);
        }

        for (int i = 0; i < numEdges; i++)
        {
            int source = random.Next(0, numVertices);
            int destination = random.Next(0, numVertices);
            int weight = random.Next(1, 100); // Assuming weights between 1 and 100

            graph.AddEdge(source, destination, weight);
        }

        return graph;
    }
}
