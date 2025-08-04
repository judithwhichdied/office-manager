using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cell : MonoBehaviour
{
    private MeshRenderer _renderer;

    private bool _isOccupied = false;

    public bool IsOccupied { get { return _isOccupied; } }

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
}