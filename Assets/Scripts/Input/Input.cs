using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    private const string TapT = nameof(TapT);
    private const string MouseClick = nameof(MouseClick);
    private const string Rotation = nameof(Rotation);

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Camera _camera;

    private InputAction _action;
    private InputAction _onClick;
    private InputAction _rotation;

    public event Action<Vector2> Tapped;
    public event Action<Cell> Clicked;
    public event Action KeyDown;

    private void Awake()
    {
        _action = _playerInput.actions.FindAction(TapT);
        _onClick = _playerInput.actions.FindAction(MouseClick);
        _rotation = _playerInput.actions.FindAction(Rotation);
    }

    private void OnEnable()
    {
        _action.performed += (context) => Tapped?.Invoke(Mouse.current.position.ReadValue());
        _onClick.performed += (context) => Clicked?.Invoke(GetCellPosition());
        _rotation.performed += (context) => KeyDown?.Invoke();
    }

    private void OnDisable()
    {
        _action.performed -= (context) => Tapped?.Invoke(Mouse.current.position.ReadValue());
        _onClick.performed -= (context) => Clicked?.Invoke(GetCellPosition());
        _rotation.performed -= (context) => KeyDown?.Invoke();
    }

    private Cell GetCellPosition()
    {
        Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray: ray, out RaycastHit hit) && hit.collider.gameObject.TryGetComponent(out Cell cell))
        {
            return cell;
        }

        return null;
    }
}