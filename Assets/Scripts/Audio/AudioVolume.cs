using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer _soundMixer;
    [SerializeField] private TMP_Text _volumeText;
    
    private readonly StorageWithNameSaveObject<AudioVolume, float> _storage = new ();
    private const string GroupName = "Master";

    [field: SerializeField] public Slider Slider { get; private set; }
    
    private void Start() => Init();

    private void Init()
    {
        Slider.onValueChanged.AddListener(ChangeSoundVolume);
        var value = _storage.HasSave() ? _storage.Load() : 0.5f;
        Slider.value = _storage.HasSave() ? value :  0.5f;
        _soundMixer.SetFloat(GroupName, ToVolume(Slider.value));
        _volumeText.text = $"{Mathf.RoundToInt(value * 100f)}%";
    }

    private void OnDisable() => Slider.onValueChanged.RemoveListener(ChangeSoundVolume);

    public void ChangeSoundVolume(float value)
    {
        _soundMixer.SetFloat(GroupName, ToVolume(value));
        _storage.Save(value);
        _volumeText.text = $"{Mathf.RoundToInt(value * 100f)}%";
    }

    private float ToVolume(float value) => Mathf.Lerp(-60, 0, value);
    
}
