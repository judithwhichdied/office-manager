using System.Collections.Generic;
using UnityEngine;

public class PathFinder
{
    private Cell[,] _grid;
    private int _width;
    private int _height;

    public PathFinder(Cell[,] grid)
    {
        _grid = grid;
        _width = grid.GetLength(0);
        _height = grid.GetLength(1);
    }

    public List<Cell> FindPath(Cell startCell, Cell targetCell)
    {
        List<Cell> reachable = new List<Cell>() { startCell};
        HashSet<Cell> visited = new HashSet<Cell>();

        Dictionary<Cell, Cell> cameFrom = new Dictionary<Cell, Cell>();

        Dictionary<Cell, float> gScore = new Dictionary<Cell, float>();
        gScore[startCell] = 0;

        Dictionary<Cell, float> fScore = new Dictionary<Cell, float>();
        fScore[startCell] = GetHeuristic(startCell, targetCell);

        while (reachable.Count > 0)
        {
            Cell current = GetLowestScoreCell(reachable, fScore);

            if (current == targetCell)
            {
                return ReconstructPath(cameFrom, current);
            }

            reachable.Remove(current);
            visited.Add(current);

            foreach (Cell neighbor in GetNeighbors(current))
            {
                if (neighbor != targetCell && (neighbor.Occupied || visited.Contains(neighbor)))
                    continue;

                float tentativeGScore = gScore[current] + 1;

                if (!reachable.Contains(neighbor))
                    reachable.Add(neighbor);
                else if (tentativeGScore >= gScore[neighbor])
                    continue;

                cameFrom[neighbor] = current;
                gScore[neighbor] = tentativeGScore;
                fScore[neighbor] = gScore[neighbor] + GetHeuristic(neighbor, targetCell);
            }
        }

        return null;
    }

    private float GetHeuristic(Cell a, Cell b)
    {
        return Mathf.Abs(a.GridX - b.GridX) + Mathf.Abs(a.GridY - b.GridY);
    }

    private Cell GetLowestScoreCell(List<Cell> reachable, Dictionary<Cell, float> fScore)
    {
        Cell lowest = reachable[0];
        float lowestScore = fScore[lowest];

        foreach (Cell cell in reachable)
        {
            if (fScore[cell] < lowestScore)
            {
                lowest = cell;
                lowestScore = fScore[cell];
            }
        }

        return lowest;
    }

    private List<Cell> ReconstructPath(Dictionary<Cell, Cell> cameFrom, Cell current)
    {
        List<Cell> path = new List<Cell>() { current };

        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            path.Insert(0, current);
        }

        return path;
    }

    private List<Cell> GetNeighbors(Cell cell)
    {
        List<Cell> neighbors = new List<Cell>();

        int[] dx = { 0, 0, -1, 1 };
        int[] dy = { 1, -1, 0, 0 };

        for (int i = 0; i < 4; i++)
        {
            int checkX = cell.GridX + dx[i];
            int checkY = cell.GridY + dy[i];

            if (checkX >= 0 && checkX < _width && checkY >= 0 && checkY < _height)
            {
                neighbors.Add(_grid[checkX, checkY]);
            }
        }

        return neighbors;
    }
}
