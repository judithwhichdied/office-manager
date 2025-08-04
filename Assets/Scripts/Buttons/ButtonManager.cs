using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private MenuManager _manager;

    private void OnEnable()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            int menuIndex = i;

            _buttons[i].onClick.AddListener(() => StartCoroutine(_manager.ShowMenu(menuIndex)));
        }
    }
}