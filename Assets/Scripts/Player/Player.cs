using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D), typeof(TargetSearcher))]
public sealed class Player : Entity
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _dashClip;
    [SerializeField] private AudioClip[] _attackClips;

    private readonly float _moveForce = 800f;
    private readonly float _dashForce = 3400f;

    private TargetSearcher _targetSearcher;
    private Rigidbody2D _rigidbody;

    public event Action Attacked;
    
    public event Action Dashing;

    public float MaxTimeForDashForce => 1f;
    
    public bool IsAttacking { get; private set; }
    
    public Vector3 MoveDirection { get; private set; }

    protected override void Enable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _targetSearcher = GetComponent<TargetSearcher>();
    }

    public void Attack()
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
        {
            Attacked?.Invoke();
            MoveTo(closest, _moveForce);
            PlayRandomAttakckAudio();
        }
    }

    public void Dash(float chargingTimeForDashForce)
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
        {
            _audioSource.PlayOneShot(_dashClip);
            Dashing?.Invoke();
            float chargedDashForce = GetChargedDashForce(chargingTimeForDashForce);
            MoveTo(closest, chargedDashForce);
        }
    }

    private void MoveTo(Entity closest, float force)
    {
        IsAttacking = true;
        Vector3 direction = (closest.transform.position - transform.position).normalized;
        MoveDirection = direction;
        _rigidbody.AddForce(direction * force);
    }

    private float GetChargedDashForce(float chargingTime)
    {
        float dashForceCoefficient = Mathf.Min(chargingTime, MaxTimeForDashForce) / MaxTimeForDashForce;
        float deltaForce = _dashForce * dashForceCoefficient;
        float result = deltaForce;
        return result;
    }

    public void StopAttack() => IsAttacking = false;

    private void PlayRandomAttakckAudio()
    {
        int number = Random.Range(0, _attackClips.Length);
        _audioSource.PlayOneShot(_attackClips[number]);
    }
}