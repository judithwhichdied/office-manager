using UnityEngine;

public class GridCreator : MonoBehaviour
{
    [SerializeField] private Cell _prefab;
    [SerializeField] private Occupator _occupator;
    [SerializeField] private UnitManager _unitManager;

    private PathFinder _pathFinder;
    private StartCellRandomizer _randomizer;

    private Vector3 _startPosition = new Vector3(-7, 0, 7);

    private int _columns = 7;
    private int _rows = 7;
    private float _spacing = 2f;

    private Cell[,] _grid;

    private void Awake()
    {
        Create();
        _occupator.OccupyCells(_grid);

        _pathFinder = new PathFinder(_grid);
        _randomizer = new StartCellRandomizer(_grid);
        _unitManager.Initialize(_pathFinder, _randomizer);
    }

    private void Create()
    {
        _grid = new Cell[_columns, _rows];

        Cell cell;

        Vector3 startPosition = Vector3.zero;

        for (int i = 0; i < _columns; i++)
        {
            transform.position = new Vector3(_startPosition.x, _startPosition.y, _startPosition.z - i * _spacing); 

            for (int j = 0; j < _rows; j++)
            {
                transform.position = new Vector3(_startPosition.x + j * _spacing, _startPosition.y, transform.position.z); 

                cell = Instantiate(_prefab, transform.position, Quaternion.identity);

                _grid[i, j] = cell;

                cell.SetGridPosition(i, j);
            }
        }
    }

    public Cell[,] GetGrid() { return _grid; }
}