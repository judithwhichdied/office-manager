using System;
using UnityEngine;

public class Placer : MonoBehaviour
{
    [SerializeField] private Desk _prefab;
    [SerializeField] private Input _input;
    [SerializeField] private DeskCreator _creator;
    [SerializeField] private GridCreator _gridCreator;

    private float _offsetY = 1f;

    private Desk _desk = null;

    public event Action<Cell> Placed;

    private void OnEnable()
    {
        _creator.Created += SetDesk;
        _input.Clicked += Place;
    }

    private void OnDisable()
    {
        _input.Clicked -= Place;
        _creator.Created -= SetDesk;
    }

    private void SetDesk(Desk desk)
    {
        if (desk != null)
            _desk = desk;
    }

    private void Place(Cell cell)
    {
        if (cell != null && cell.Occupied == false)
        {
            _desk.transform.position = new Vector3(cell.transform.position.x, _offsetY, cell.transform.position.z);
            _desk.GetComponent<BoxCollider>().enabled = true;

            cell.Occupy();
            cell.SetColor(default);

            Cell frontCell = GetFrontCell(cell, _desk.transform.rotation);

            Placed?.Invoke(frontCell);
        }
    }

    private Cell GetFrontCell(Cell deskCell, Quaternion deskRotation)
    {
        Vector3 forward = deskRotation * Vector3.forward;

        int offsetX = 0;
        int offsetZ = 0;

        if (Mathf.Abs(forward.x) > Mathf.Abs(forward.z))
        {
            offsetX = forward.x > 0 ? 1 : -1;
        }
        else
        {
            offsetZ = forward.z > 0 ? 1 : -1;
        }

        Cell[,] grid = _gridCreator.GetGrid();
        
        int width = grid.GetLength(0);
        int height = grid.GetLength(1);

        int frontX = deskCell.GridX + offsetX;
        int frontZ = deskCell.GridY + offsetZ;

        if (frontX >= 0 && frontX < width && frontZ >= 0 && frontZ < height)
        {
            return grid[frontX, frontZ];
        }

        return null;
    }
}