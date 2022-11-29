using UnityEngine;

public sealed class PlayerSoundView : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _attackClips;
    [SerializeField] private AudioClip _dashClip;

    public void PlayDash()
    {
        _audioSource.PlayOneShot(_dashClip);
    }
    
    public void PlayRandomAttack()
    {
        int number = Random.Range(0, _attackClips.Length);
        _audioSource.PlayOneShot(_attackClips[number]);
    }
}