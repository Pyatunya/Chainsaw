using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public sealed class DashAoeDamager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField, Min(1)] private int _damage = 5;
    
    private float _time = 0.5f;
    private float _startRadius = 0.7f;
    private float _maxRadius = 1.5f;
    private CircleCollider2D _circleCollider;
    private Coroutine _activateZoneRoutine;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
        _player.Dashing += OnDashing;
    }

    private void Start()
    {
        _circleCollider.isTrigger = true;
        _circleCollider.radius = _startRadius;
        _circleCollider.enabled = false;
    }

    private void OnDisable()
    {
        _player.Dashing -= OnDashing;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Health>(out Health health))
        {
            Attack(health);
        }
    }

    private void OnDashing(float chargeTime)
    {
        CalculateAndSetRadius(chargeTime);
        _activateZoneRoutine = StartCoroutine(ActivateZone());
    }

    private IEnumerator ActivateZone()
    {
        if (_activateZoneRoutine != null)
            StopCoroutine(_activateZoneRoutine);

        WaitForSeconds timer = new WaitForSeconds(_time);
        _circleCollider.enabled = true;
        yield return timer;

        _circleCollider.enabled = false;
    }

    private void Attack(Health health)
    {
        health.TakeDamage(_damage);
    }

    private void CalculateAndSetRadius(float chargeTime)
    {
        float chargeCoefficient = Mathf.Min(chargeTime, _player.MaxTimeForDashForce) / _player.MaxTimeForDashForce;
        float radius = ((_maxRadius - _startRadius) * chargeCoefficient) + _startRadius;
        _circleCollider.radius = radius;
    }
}