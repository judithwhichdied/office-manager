using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class ButtonView : MonoBehaviour
{
    private Vector3 _targetScale = Vector3.one;
    private float _time = 0.1f;
    private Image _image;
    private Button _button;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(() => Animate());
    }

    public void Animate()
    {
        transform.DOScale(_targetScale, _time).SetLoops(2, LoopType.Yoyo);
        _image.DOColor(Color.blue, _time).SetLoops(2, LoopType.Yoyo); 
    }
}