using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class CursorFollower : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private DeskCreator _deskCreator;
    [SerializeField] private Placer _placer;

    private Color _free = Color.green;
    private Color _occupied = Color.red;

    private bool _canFollow = true;

    private void OnEnable()
    {
        _deskCreator.Created += Follow;
        _placer.Placed += StopFollowing;
    }

    private void OnDisable()
    {
        _deskCreator.Created -= Follow;
        _placer.Placed -= StopFollowing;
    }

    private void Follow(Desk desk)
    {
        StartCoroutine(StartFollowing(desk));
    }

    private void StopFollowing(Cell _)
    {
        _canFollow = false;
    }

    private IEnumerator StartFollowing(Desk desk)
    {
        Ray ray;

        float offsetY = 3f;

        Cell pastCell = null;

        Vector3 position;
    
        while (_canFollow)
        {
            ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray: ray, out RaycastHit hit) && hit.collider)
            {
                position = new Vector3(hit.point.x, offsetY, hit.point. z);

                desk.transform.position = position;

                if (pastCell != null)
                    pastCell.SetColor(default);

                if (hit.collider.gameObject.TryGetComponent(out Cell cell))
                {
                    if (cell.Occupied)
                        cell.SetColor(_occupied);
                    else
                        cell.SetColor(_free);

                    pastCell = cell;
                }       
            }

            yield return null;
        }

        _canFollow = true;
    }
}