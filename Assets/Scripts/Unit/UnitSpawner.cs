using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private UnitMover _prefab;
    [SerializeField] private Transform _spawnPoint;

    private ObjectPool<UnitMover> _pool;

    private int _poolCapacity = 5;
    private int _poolMaxSize = 5;

    private void Awake()
    {
        _pool = new ObjectPool<UnitMover>
           (
                createFunc: () => Instantiate(_prefab),
                actionOnGet: OnGet,
                actionOnRelease: (unit) => OnRelease(unit),
                actionOnDestroy: (unit) => Destroy(unit.gameObject),
                collectionCheck: true,
                defaultCapacity: _poolCapacity,
                maxSize: _poolMaxSize
           );
    }

    private void OnGet(UnitMover unit)
    {
        unit.transform.position = _spawnPoint.position;
        unit.GetComponent<NavMeshAgent>().enabled = true;
    }

    private void OnRelease(UnitMover unit)
    {

    }

    public UnitMover Spawn()
    {
        return _pool.Get();
    }
}