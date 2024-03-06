using System;
using System.Collections.Generic;

class MazeSolver
{
    private char[,] maze;
    private int width;
    private int height;
    private bool[,] visited;

    public MazeSolver(char[,] maze)
    {
        this.maze = maze;
        height = maze.GetLength(0);
        width = maze.GetLength(1);
        visited = new bool[height, width];
    }

    public void DFS(int startX, int startY)
    {
        Console.WriteLine("DFS Path:");
        DFSUtil(startX, startY);
        Console.WriteLine();
    }

    private void DFSUtil(int x, int y)
    {
        visited[y, x] = true;
        Console.Write($"({x},{y}) ");

        // Possible moves: up, down, left, right
        int[] dx = { 0, 0, -1, 1 };
        int[] dy = { -1, 1, 0, 0 };

        for (int i = 0; i < 4; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];
            if (nx >= 0 && nx < width && ny >= 0 && ny < height && maze[ny, nx] == ' ' && !visited[ny, nx])
            {
                DFSUtil(nx, ny);
            }
        }
    }

    public void BFS(int startX, int startY)
    {
        Console.WriteLine("BFS Path:");
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { startX, startY });

        while (queue.Count > 0)
        {
            int[] current = queue.Dequeue();
            int x = current[0];
            int y = current[1];
            Console.Write($"({x},{y}) ");
            visited[y, x] = true;

            // Possible moves: up, down, left, right
            int[] dx = { 0, 0, -1, 1 };
            int[] dy = { -1, 1, 0, 0 };

            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];
                if (nx >= 0 && nx < width && ny >= 0 && ny < height && maze[ny, nx] == ' ' && !visited[ny, nx])
                {
                    queue.Enqueue(new int[] { nx, ny });
                    visited[ny, nx] = true;
                }
            }
        }
        Console.WriteLine();
    }
}