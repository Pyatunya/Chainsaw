using UnityEngine;
using UnityEngine.UI;

public sealed class LoadingBar : MonoBehaviour
{
    [SerializeField] private Image _slider;
    private static Image _bar;

    private void Start()
    {
        _bar = _slider;
    }

    public static void Visualize(float value)
    {
        if (_bar != null)
            _bar.fillAmount = value;
    }
}