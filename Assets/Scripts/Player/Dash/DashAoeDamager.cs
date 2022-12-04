using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public sealed class DashAoeDamager : MonoBehaviour
{
    [SerializeField] private Player _player;
    private int _damage;

    private const float Time = 0.5f;
    private const float StartRadius = 0.7f;
    private const float MaxRadius = 1.5f;
    private CircleCollider2D _circleCollider;
    private Coroutine _activateZoneRoutine;

    private void Awake()
    {
        var storage = new StorageWithNameSaveObject<DashAoeDamager, int>();
        _damage = storage.HasSave() ? storage.Load() : 5;
        _circleCollider = GetComponent<CircleCollider2D>();
        _player.Dashing += OnDashing;
    }

    private void Start()
    {
        _circleCollider.isTrigger = true;
        _circleCollider.radius = StartRadius;
        _circleCollider.enabled = false;
    }

    private void OnDisable() => _player.Dashing -= OnDashing;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Health health))
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

        WaitForSeconds timer = new WaitForSeconds(Time);
        _circleCollider.enabled = true;
        yield return timer;

        _circleCollider.enabled = false;
    }

    private void Attack(Health health) => health.TakeDamage(_damage);

    private void CalculateAndSetRadius(float chargeTime)
    {
        float chargeCoefficient = Mathf.Min(chargeTime, _player.MaxTimeForDashForce) / _player.MaxTimeForDashForce;
        float radius = ((MaxRadius - StartRadius) * chargeCoefficient) + StartRadius;
        _circleCollider.radius = radius;
    }
}