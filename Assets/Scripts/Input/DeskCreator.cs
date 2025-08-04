using System;
using UnityEngine;

public class DeskCreator : MonoBehaviour
{
    [SerializeField] private Desk _prefab;
    [SerializeField] private Input _input;

    public event Action<Desk> Created;

    private void OnEnable()
    {
        _input.Tapped += Create;
    }

    private void OnDisable()
    {
        _input.Tapped -= Create;    
    }

    private void Create(Vector2 position)
    {
        Desk desk = Instantiate(_prefab, position, Quaternion.identity);

        Created?.Invoke(desk);
    }
}