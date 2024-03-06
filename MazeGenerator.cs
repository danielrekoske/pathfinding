using System;
using System.Collections.Generic;

class MazeGenerator
{
    private int width;
    private int height;
    private char[,] maze;
    private Random rand;

    public MazeGenerator(int width, int height)
    {
        this.width = width;
        this.height = height;
        maze = new char[height, width];
        rand = new Random();
        Initialize();
        GenerateMaze(0, 0);
    }

    private void Initialize()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                maze[i, j] = '#'; // walls
            }
        }
    }

    private void GenerateMaze(int x, int y)
    {
        maze[y, x] = ' '; // clear current cell
        List<int[]> neighbors = GetNeighbors(x, y);
        while (neighbors.Count > 0)
        {
            int[] neighbor = neighbors[rand.Next(neighbors.Count)];
            int nx = neighbor[0];
            int ny = neighbor[1];
            if (maze[ny, nx] == '#')
            {
                // Remove the wall between the current cell and the chosen neighbor
                maze[(ny + y) / 2, (nx + x) / 2] = ' ';
                GenerateMaze(nx, ny);
            }
            neighbors.Remove(neighbor);
        }
    }

    private List<int[]> GetNeighbors(int x, int y)
    {
        List<int[]> neighbors = new List<int[]>();
        if (x >= 2) neighbors.Add(new int[] { x - 2, y });
        if (y >= 2) neighbors.Add(new int[] { x, y - 2 });
        if (x < width - 2) neighbors.Add(new int[] { x + 2, y });
        if (y < height - 2) neighbors.Add(new int[] { x, y + 2 });
        Shuffle(neighbors);
        return neighbors;
    }

    private void Shuffle<T>(IList<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public void PrintMaze()
    {
        Console.WriteLine("Generated Maze:");
        Console.WriteLine(new string('-', width * 2 + 1));
        for (int i = 0; i < height; i++)
        {
            Console.Write("|");
            for (int j = 0; j < width; j++)
            {
                Console.Write(maze[i, j]);
                Console.Write(" ");
            }
            Console.WriteLine("|");
        }
        Console.WriteLine(new string('-', width * 2 + 1));
    }

    public char[,] GetMaze()
    {
        return maze;
    }
}
