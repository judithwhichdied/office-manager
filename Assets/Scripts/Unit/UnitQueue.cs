using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitQueue : MonoBehaviour
{
    [SerializeField] private UnitSpawner _spawner;

    private Queue<UnitMover> _queue;

    private void Awake()
    {
        _queue = new Queue<UnitMover>();
    }

    public void CreateQueue(int unitCount, Cell startCell)
    {
        for (int i = 0; i < unitCount; i++)
        {
            _queue.Enqueue(_spawner.Spawn(startCell));
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