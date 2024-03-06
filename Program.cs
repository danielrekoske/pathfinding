class Program
{
    static void Main(string[] args)
    {
        // Define maze size
        int width = 10;
        int height = 10;

        // Generate maze
        MazeGenerator generator = new MazeGenerator(width, height);
        generator.PrintMaze();

        // Solve maze using DFS
        char[,] maze = generator.GetMaze();
        MazeSolver solverDFS = new MazeSolver(maze);
        solverDFS.DFS(0, 0);

        // Solve maze using BFS
        MazeSolver solverBFS = new MazeSolver(maze);
        solverBFS.BFS(0, 0);
    }
}