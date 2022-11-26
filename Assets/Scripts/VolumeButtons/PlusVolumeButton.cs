using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public sealed class PlusVolumeButton : MonoBehaviour
{
    [SerializeField] private AudioVolume _audioVolume;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _audioVolume.ChangeSoundVolume(_audioVolume.Slider.value + 0.1f);
    }
}