using System.Collections;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private MainMenu _main;
    [SerializeField] private Menu[] _menus;

    private void Start()
    {
        _main.Show();
    }

    public IEnumerator ShowMenu(int index)
    {
        WaitForSeconds wait = new WaitForSeconds(0.15f);

        yield return wait;

        if (_main.isActiveAndEnabled)
        {
            _main.gameObject.SetActive(false);
        }

        for (int i = 0; i < _menus.Length; i++)
        {
            _menus[i].gameObject.SetActive(_menus[i] == _menus[index]);
        }
    }
}