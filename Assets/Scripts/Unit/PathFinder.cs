using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private UnitQueue _queue;
    [SerializeField] private Placer _placer;

    private void OnEnable()
    {
        _placer.Placed += SendUnit;
    }

    private void OnDisable()
    {
        _placer.Placed -= SendUnit;
    }

    private void SendUnit(Vector3 position)
    {
        UnitMover unit = _queue.GetFirstUnit();

        if (unit != null)
        {
            unit.Move(position);
        }
    }
}