using System;
using UnityEngine;

[RequireComponent(typeof(TargetSearcher))]
public sealed class Player : Entity
{
    [SerializeField] private PlayerSoundView _soundView;
    
    private readonly float _dashForce = 3400f;
    private readonly DashForceCalculator _dashForceCalculator = new();
    private TargetSearcher _targetSearcher;

    public event Action Attacked;
    
    public event Action<float> Dashing;
    
    [field: SerializeField] public PlayerMovement Movement { get; private set; }

    public readonly float MaxTimeForDashForce = 1f;
    
    public bool IsAttacking { get; private set; }

    protected override void Enable() => _targetSearcher = GetComponent<TargetSearcher>();

    public async void Attack()
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
        {
            Attacked?.Invoke();
            IsAttacking = true;
            await Movement.MoveTo(closest);
            _targetSearcher.ZombieSearch(out Collider2D[] hitEnemies);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>().TakeDamage(1);
            }

            _soundView.PlayRandomAttack();
        }
    }

    public void Dash(float chargingTimeForDashForce)
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
        {
            Dashing?.Invoke(chargingTimeForDashForce);
            float  chargedDashForce = _dashForceCalculator.CalculateFrom(chargingTimeForDashForce, _dashForce, MaxTimeForDashForce);
            Movement.DashTo(closest, chargedDashForce);
            _soundView.PlayDash();
        }
    }

    public void StopAttack() => IsAttacking = false;
    
}