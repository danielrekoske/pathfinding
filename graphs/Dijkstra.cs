public class Dijkstra
{
    public Dictionary<int, int> FindShortestPath(Graph graph, int startVertex)
    {
        var distances = new Dictionary<int, int>();
        var priorityQueue = new PriorityQueue<int>();
        var visited = new HashSet<int>();

        foreach (var vertex in graph.GetAdjacencyList().Keys)
        {
            distances[vertex] = int.MaxValue;
        }

        distances[startVertex] = 0;
        priorityQueue.Enqueue(startVertex, 0);

        while (priorityQueue.Count > 0)
        {
            var (currentVertex, currentDistance) = priorityQueue.Dequeue();

            if (visited.Contains(currentVertex)) continue;

            visited.Add(currentVertex);

            foreach (var (neighbor, weight) in graph.GetAdjacencyList()[currentVertex])
            {
                var newDistance = currentDistance + weight;
                if (newDistance < distances[neighbor])
                {
                    distances[neighbor] = newDistance;
                    priorityQueue.Enqueue(neighbor, newDistance);
                }
            }
        }

        return distances;
    }
}

public class PriorityQueue<T>
{
    private SortedDictionary<T, Queue<T>> _sortedDict;

    public PriorityQueue()
    {
        _sortedDict = new SortedDictionary<T, Queue<T>>();
    }

    public int Count { get; private set; }

    public void Enqueue(T item, T priority)
    {
        if (!_sortedDict.ContainsKey(priority))
            _sortedDict[priority] = new Queue<T>();

        _sortedDict[priority].Enqueue(item);
        Count++;
    }

    public (T, T) Dequeue()
    {
        if (Count == 0)
            throw new InvalidOperationException("Queue is empty");

        var priority = _sortedDict.Keys.First();
        var item = _sortedDict[priority].Dequeue();
        if (_sortedDict[priority].Count == 0)
            _sortedDict.Remove(priority);

        Count--;
        return (item, priority);
    }
}