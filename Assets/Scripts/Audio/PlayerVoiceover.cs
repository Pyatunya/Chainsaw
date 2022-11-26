using System.Collections;
using UnityEngine;

public class PlayerVoiceover : MonoBehaviour
{
    [SerializeField] private PlayerInputController _inputController;
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioSource _audioSource;

    private bool _canPlay = true;

    private void OnEnable()
    {
        Debug.Log(_inputController == null);
        _inputController.DashChargingCompleted += OnDashChargingStarted;
    }

    private void OnDisable()
    {
        _inputController.DashChargingCompleted -= OnDashChargingStarted;
    }

    private void OnDashChargingStarted() => PlayRandomAudio();

    private void PlayRandomAudio()
    {
        if (_canPlay)
        {
            if (GetChanceToPlay())
            {
                int number = Random.Range(0, _audioClips.Length);
                _audioSource.PlayOneShot(_audioClips[number]);
                StartCoroutine(StartDelay());
            }
        }
    }

    private IEnumerator StartDelay()
    {
        _canPlay = false;
        float delaySeconds = 3f;
        yield return new WaitForSeconds(delaySeconds);
        _canPlay = true;
    }

    private bool GetChanceToPlay()
    {
        int luckyNumber = 1;
        int number = Random.Range(0, 3);
        return number == luckyNumber;
    }
}