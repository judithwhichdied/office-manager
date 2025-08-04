using UnityEngine;

public class DeskRotator : MonoBehaviour
{
    [SerializeField] private DeskCreator _creator;
    [SerializeField] private Input _input;

    private Desk _desk;

    private void OnEnable()
    {
        _creator.Created += SetDesk;
        _input.KeyDown += Rotate;
    }

    private void OnDisable()
    {
        _creator.Created -= SetDesk;
        _input.KeyDown -= Rotate;
    }

    private void SetDesk(Desk desk)
    {
        if (desk != null)
            _desk = desk;
    }

    private void Rotate()
    {
        Vector3 rotation = new Vector3(0, 90, 0);

        _desk.transform.Rotate(rotation);
    }
}