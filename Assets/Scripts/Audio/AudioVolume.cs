using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer _soundMixer;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private TMP_Text _volumeText;
    
    private readonly StorageWithNameSaveObject<AudioVolume, float> _storage = new ();
    private const string GroupName = "Master";

    private void Start() => Init();

    private void Init()
    {
        _soundSlider.onValueChanged.AddListener(ChangeSoundVolume);
        var value = _storage.HasSave() ? _storage.Load() : 0.5f;
        _soundSlider.value = _storage.HasSave() ? value :  0.5f;
        _soundMixer.SetFloat(GroupName, ToVolume(_soundSlider.value));
        _volumeText.text = $"{Mathf.RoundToInt(value * 100f)}%";
    }

    private void OnDisable() => _soundSlider.onValueChanged.RemoveListener(ChangeSoundVolume);

    private void ChangeSoundVolume(float value)
    {
        _soundMixer.SetFloat(GroupName, ToVolume(value));
        _storage.Save(value);
        _volumeText.text = $"{Mathf.RoundToInt(value * 100f)}%";
    }

    private float ToVolume(float value) => Mathf.Lerp(-60, 0, value);
    
}
