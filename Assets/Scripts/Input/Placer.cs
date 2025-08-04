using System;
using UnityEngine;

public class Placer : MonoBehaviour
{
    [SerializeField] private Desk _prefab;
    [SerializeField] private Input _input;
    [SerializeField] private DeskCreator _creator;

    private float _offsetY = 1f;

    private Desk _desk = null;

    public event Action<Vector3> Placed;

    private void OnEnable()
    {
        _creator.Created += SetDesk;
        _input.Clicked += Place;
    }

    private void OnDisable()
    {
        _input.Clicked -= Place;
        _creator.Created -= SetDesk;
    }

    private void SetDesk(Desk desk)
    {
        if (desk != null)
            _desk = desk;
    }

    private void Place(Cell cell)
    {
        if (cell != null && cell.IsOccupied == false)
        {
            _desk.transform.position = new Vector3(cell.transform.position.x, _offsetY, cell.transform.position.z);
            _desk.GetComponent<BoxCollider>().enabled = true;

            cell.Occupy();
            cell.SetColor(default);

            Placed?.Invoke(_desk.transform.position);
        }
    }
}