using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour
{
    private float _speed = 3f;
    private Coroutine _movingCoroutine;

    public void Move(List<Cell> path)
    {
        _movingCoroutine = StartCoroutine(StartMoving(path));
    }

    private IEnumerator StartMoving(List<Cell> path)
    {
        if (_movingCoroutine != null)
        {
            yield break;
        }

        for (int i = 0; i < path.Count; i++)
        {
            Vector3 targetPosition = path[i].transform.position;

            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards
                    (transform.position, targetPosition, _speed * Time.deltaTime);
                yield return null;
            }

            transform.position = targetPosition;
        }

        _movingCoroutine = null;
    }
}