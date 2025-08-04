using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitQueue : MonoBehaviour
{
    [SerializeField] private UnitSpawner _spawner;

    private Queue<UnitMover> _queue;

    private int _unitCount = 5;

    private void Awake()
    {
        _queue = new Queue<UnitMover>();
    }

    private void Start()
    {
        CreateQueue();
    }

    private void CreateQueue()
    {
        for (int i = 0; i < _unitCount; i++)
        {
            _queue.Enqueue(_spawner.Spawn());
        }
    }

    private bool TryGetUnit()
    {
        if (_queue.Count > 0)
            return true;

        return false;
    }

    public UnitMover GetFirstUnit()
    {
        if (TryGetUnit())
        {
            return _queue.Dequeue();
        }

        return null;
    }
}