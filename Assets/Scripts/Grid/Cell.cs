using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cell : MonoBehaviour
{
    private MeshRenderer _renderer;

    private int _gridX;
    private int _gridY; 

    private bool _isOccupied = false;

    public int GridX => _gridX;
    public int GridY => _gridY;

    public bool Occupied => _isOccupied;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        SetColor(default);
    }

    public void Occupy()
    {
        _isOccupied = true;
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }

    public void SetGridPosition(int gridX, int gridY)
    {
        _gridX = gridX;
        _gridY = gridY;
    }
}