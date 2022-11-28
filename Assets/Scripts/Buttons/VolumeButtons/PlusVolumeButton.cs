using UnityEngine;

[RequireComponent(typeof(Button))]
public sealed class PlusVolumeButton : Button
{
    [SerializeField] private AudioVolume _audioVolume;

    private float Value => _audioVolume.Slider.value;

    protected override void OnClick()
    {
        _audioVolume.ChangeSoundVolume(Value + 0.05f);
    }
}