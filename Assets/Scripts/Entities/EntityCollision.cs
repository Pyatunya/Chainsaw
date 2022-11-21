using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class EntityCollision : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage = 5;
    [SerializeField, Min(0.1f)] private float _attackDelay = 0.5f;
    
    private ComboCounter _comboCounter;
    private Coroutine _coroutine;

    private void OnEnable() => _comboCounter ??= GetComponent<ComboCounter>();

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            if (_coroutine is not null)
                StopCoroutine(_coroutine);
            
            _coroutine = StartCoroutine(StartAttacking(player.Health));
        }
    }

    private IEnumerator StartAttacking(Health health)
    {
        yield return new WaitForSeconds(_attackDelay);
        health.TakeDamage(_damage);
        _comboCounter?.ResetToZero();
    }
}