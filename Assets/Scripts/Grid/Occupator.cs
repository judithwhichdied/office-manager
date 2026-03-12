using UnityEngine;

public class Occupator : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;

    private int _occupiedCellsCount;

    public void OccupyCells(Cell[,] grid)
    {
        int totalCells = grid.GetLength(0) * grid.GetLength(1);
        int minCount = 1;
        int maxCount = Mathf.RoundToInt(totalCells / 3f);

        _occupiedCellsCount = Random.Range(minCount, maxCount ++);

        int attempts = 0;
        int maxAttempts = 100;

        for (int i = 0; i < _occupiedCellsCount && attempts < maxAttempts; attempts++)
        {
            int randomColumn = Random.Range(0, grid.GetLength(0));
            int randomRow = Random.Range(0, grid.GetLength(1));

            Cell cell = grid[randomColumn, randomRow];

            if (TryOccupy(cell) && !HasOccupiedNeighbors(grid, randomColumn, randomRow))
            {
                Instantiate(_obstaclePrefab, cell.transform.position, Quaternion.identity);
                cell.Occupy();
                i++; 
            }
        }
    }

    private bool HasOccupiedNeighbors(Cell[,] grid, int x, int y)
    {      
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue; 

                int neighborX = x + i;
                int neighborY = y + j;
              
                if (neighborX >= 0 && neighborX < grid.GetLength(0) &&
                    neighborY >= 0 && neighborY < grid.GetLength(1))
                {
                    if (grid[neighborX, neighborY].Occupied)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private bool TryOccupy(Cell cell)
    {
        if (cell.Occupied)
            return false;

        return true;
    }
}