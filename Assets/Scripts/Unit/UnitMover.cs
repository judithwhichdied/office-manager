using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnitMover : MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 targetPosition)
    {
        _agent.SetDestination(targetPosition);
    }
}