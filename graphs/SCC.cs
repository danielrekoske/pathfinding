public class SCC
{
    private Graph _graph;
    private List<List<int>> _stronglyConnectedComponents;
    private Stack<int> _stack;
    private HashSet<int> _visited;
    private Dictionary<int, int> _lowLink;
    private Dictionary<int, int> _ids;
    private int _id;
    
    public SCC(Graph graph)
    {
        _graph = graph;
        _stronglyConnectedComponents = new List<List<int>>();
        _stack = new Stack<int>();
        _visited = new HashSet<int>();
        _lowLink = new Dictionary<int, int>();
        _ids = new Dictionary<int, int>();
        _id = 0;
    }
    
    public List<List<int>> FindSCCs()
    {
        foreach (var vertex in _graph.GetAdjacencyList().Keys)
        {
            if (!_visited.Contains(vertex))
                DFS(vertex);
        }

        return _stronglyConnectedComponents;
    }
    
    private void DFS(int vertex)
    {
        _visited.Add(vertex);
        _lowLink[vertex] = _id;
        _ids[vertex] = _id;
        _id++;
        _stack.Push(vertex);
        
        if (_graph.GetAdjacencyList().ContainsKey(vertex))
        {
            foreach (var neighbor in _graph.GetAdjacencyList()[vertex].Keys)
            {
                if (!_visited.Contains(neighbor))
                {
                    DFS(neighbor);
                    _lowLink[vertex] = Math.Min(_lowLink[vertex], _lowLink[neighbor]);
                }
                else if (_stack.Contains(neighbor))
                {
                    _lowLink[vertex] = Math.Min(_lowLink[vertex], _ids[neighbor]);
                }
            }
        }

        if (_lowLink[vertex] == _ids[vertex])
        {
            List<int> component = new List<int>();
            int curr;
            do
            {
                curr = _stack.Pop();
                component.Add(curr);
            } while (curr != vertex);

            _stronglyConnectedComponents.Add(component);
        }
    }
}
