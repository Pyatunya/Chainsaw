using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public sealed class PlusVolumeButton : MonoBehaviour
{
    [SerializeField] private AudioVolume _audioVolume;
    private Button _button;

    private float Value => _audioVolume.Slider.value;
    
    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _audioVolume.ChangeSoundVolume(Value + 0.05f);
    }

    private void OnDestroy() => _button.onClick.RemoveListener(OnClick);
    
}