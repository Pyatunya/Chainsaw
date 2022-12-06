using UnityEngine;
using UnityEngine.UI;

public sealed class NextTutorialButton : Button
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _sprites;
    private int _index;

    private void OnEnable()
    {
        _image.sprite = _sprites[0];
        _index = 0;
    }

    protected override void OnClick()
    {
        _index++;

        if (_index == _sprites.Length)
            _index = 0;

        _image.sprite = _sprites[_index];
    }
}
