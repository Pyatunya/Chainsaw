using System;
using UnityEngine;

[RequireComponent(typeof(TargetSearcher))]
public sealed class Player : Entity
{
    [SerializeField] private PlayerSoundView _soundView;

    private readonly float _moveForce = 800f;
    private readonly float _dashForce = 3400f;
    private readonly DashForceCalculator _dashForceCalculator = new();
    private TargetSearcher _targetSearcher;

    public event Action Attacked;
    
    public event Action<float> Dashing;
    
    [field: SerializeField] public PlayerMovement Movement { get; private set; }

    public readonly float MaxTimeForDashForce = 1f;
    
    public bool IsAttacking { get; private set; }

    protected override void Enable() => _targetSearcher = GetComponent<TargetSearcher>();

    public void Attack()
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
        {
            Attacked?.Invoke();
            MoveTo(closest, _moveForce);
            _soundView.PlayRandomAttack();
        }
    }

    public void Dash(float chargingTimeForDashForce)
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
        {
            Dashing?.Invoke(chargingTimeForDashForce);
            float  chargedDashForce = _dashForceCalculator.CalculateFrom(chargingTimeForDashForce, _dashForce, MaxTimeForDashForce);
            MoveTo(closest, chargedDashForce);
            _soundView.PlayDash();
        }
    }

    private void MoveTo(Entity closest, float chargedDashForce)
    {
        IsAttacking = true;
        Movement.MoveTo(closest, chargedDashForce);
    }
    
    public void StopAttack() => IsAttacking = false;
    
}