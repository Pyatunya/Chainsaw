using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public sealed class DashAoeDamager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField, Min(1)] private int _damage = 5;
    [SerializeField] private float _radius = 2f;
    [SerializeField] private float _time = 0.5f;

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
        _circleCollider.radius = _radius;
        _circleCollider.enabled = false;
    }

    private void OnDisable()
    {
        _player.Dashing -= OnDashing;
    }

    private void OnDashing()
    {
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Health>(out Health health))
        {
            Attack(health);
        }
    }

    private void Attack(Health health)
    {
        health.TakeDamage(_damage);
    }
}