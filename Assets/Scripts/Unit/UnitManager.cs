using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private Placer _placer;
    [SerializeField] private UnitQueue _queue;

    private PathFinder _pathfinder;
    private StartCellRandomizer _randomizer;

    private Cell _startCell;

    private void Start()
    {
        _queue.CreateQueue(5, _startCell);
    }

    private void OnEnable()
    {
        _placer.Placed += SendUnit;
    }

    private void OnDisable()
    {
        _placer.Placed -= SendUnit;
    }

    private void SendUnit(Cell targetCell)
    {
        UnitMover unit = _queue.GetFirstUnit();

        unit.Move(_pathfinder.FindPath(_startCell, targetCell));
    }

    public void Initialize(PathFinder pathFinder, StartCellRandomizer startCellRandomizer)
    {
        _pathfinder = pathFinder;
        _randomizer = startCellRandomizer;
        _startCell = _randomizer.GetStartCell();
    }
}