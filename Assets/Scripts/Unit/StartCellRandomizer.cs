using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCellRandomizer
{
    private Cell[,] _grid;
    private int _width;
    private int _height;

    public StartCellRandomizer(Cell[,] grid) 
    {
        _grid = grid;
        _width = _grid.GetLength(0);
        _height = _grid.GetLength(1);
    }

    public Cell GetStartCell()
    {
        List<Cell> outsideCells = GetOutsideCells();

        return outsideCells[Random.Range(0, outsideCells.Count)];
    }

    private List<Cell> GetOutsideCells()
    {
        List<Cell> outsideCells = new List<Cell>();

        foreach (Cell cell in _grid)
        {
            if (cell.GridX == 0 || cell.GridX == _width - 1 ||
                cell.GridY == 0 || cell.GridY == _height - 1)
            {
                if (!cell.Occupied)
                {
                    outsideCells.Add(cell);
                }
            }
        }

        return outsideCells;
    }
}