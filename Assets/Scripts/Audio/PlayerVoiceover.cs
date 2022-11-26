using System.Collections;
using UnityEngine;

public class PlayerVoiceover : MonoBehaviour
{
    [SerializeField] private PlayerInputController _inputController;
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioSource _audioSource;

    private bool _canPlay = true;

    private bool CanPlay => _canPlay && GetChanceToPlay();

    private void OnEnable()
    {
        _inputController.DashChargingCompleted += OnDashChargingStarted;
    }

    private void OnDisable()
    {
        _inputController.DashChargingCompleted -= OnDashChargingStarted;
    }

    private void OnDashChargingStarted() => PlayRandomAudio();

    private void PlayRandomAudio()
    {
        if (CanPlay)
        {
            int number = Random.Range(0, _audioClips.Length);
            _audioSource.PlayOneShot(_audioClips[number]);
            StartCoroutine(StartDelay());
        }
    }

    private IEnumerator StartDelay()
    {
        _canPlay = false;
        var delaySeconds = 3f;
        yield return new WaitForSeconds(delaySeconds);
        _canPlay = true;
    }

    private bool GetChanceToPlay()
    {
        const int luckyNumber = 1;
        var number = Random.Range(0, 3);
        return number == luckyNumber;
    }
}