using System;
using System.Collections.Generic;

public class TransitiveClosure
{
    private bool[,] reachable;
    private List<int>[] adjacencyList;
    private bool[] visited;

    
    public TransitiveClosure(int numVertices)
    {
        reachable = new bool[numVertices, numVertices];
        adjacencyList = new List<int>[numVertices];
        visited = new bool[numVertices];

        for (int i = 0; i < numVertices; i++)
        {
            adjacencyList[i] = new List<int>();
        }
    }

    
    public void AddEdge(int u, int v)
    {
        adjacencyList[u].Add(v);
    }

   
    private void DFS(int startVertex, int currentVertex)
    {
        reachable[startVertex, currentVertex] = true;
        visited[currentVertex] = true;

        foreach (int neighbor in adjacencyList[currentVertex])
        {
            if (!visited[neighbor])
            {
                DFS(startVertex, neighbor);
            }
        }
    }

    
    public void ComputeClosure()
    {
        int numVertices = reachable.GetLength(0);

        for (int i = 0; i < numVertices; i++)
        {
            visited = new bool[numVertices];
            DFS(i, i);
        }
    }

    
    public bool IsReachable(int u, int v)
    {
        return reachable[u, v];
    }
}

