using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(TargetSearcher))]
public class Player : Entity
{
    private float _moveForce = 500f;
    private float _dashForce = 2800f;
    private float _maxTimeForDashForce = 1.2f;

    private TargetSearcher _targetSearcher;
    private Rigidbody2D _rigidbody;

    public event UnityAction Dashing;

    public float MaxTimeForDashForce => _maxTimeForDashForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _targetSearcher = GetComponent<TargetSearcher>();
    }

    public void Attack()
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
            MoveTo(closest, _moveForce);
    }

    public void Dash(float chargingTimeForDashForce)
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
        {
            Dashing?.Invoke();
            float chargedDashForce = GetChargedDashForce(chargingTimeForDashForce);
            MoveTo(closest, chargedDashForce);
        }
        MoveTo(closest, _dashForce);
    }

    private void MoveTo(Entity closest, float force)
    {
        var direction = (closest.transform.position - transform.position).normalized;
        _rigidbody.AddForce(direction * force);
    }

    private float GetChargedDashForce(float chargingTime)
    {
        float dashForceCoefficient = Mathf.Min(chargingTime, _maxTimeForDashForce) / _maxTimeForDashForce;
        float deltaForce = (_dashForce - _moveForce) * dashForceCoefficient;
        float result = deltaForce + _moveForce;
        return result;
    }
}