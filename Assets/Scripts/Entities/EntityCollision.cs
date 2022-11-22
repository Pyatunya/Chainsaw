using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class EntityCollision : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage = 5;
    [SerializeField, Min(0.1f)] private float _attackDelay = 0.5f;

    private ComboCounter _comboCounter;
    private Coroutine _coroutine;
    private float _collisionTime = 0f;

    private void OnEnable() => _comboCounter ??= GetComponent<ComboCounter>();

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            _collisionTime += Time.deltaTime;

            if (_collisionTime > _attackDelay)
            {
                if (gameObject.activeSelf)
                    Attack(player.Health);

                _collisionTime = 0f;
            }

            // if (_coroutine is not null)
            //     StopCoroutine(_coroutine);

            // if (gameObject.activeSelf == true)
            //     _coroutine = StartCoroutine(StartAttacking(player.Health));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            _collisionTime = 0f;
        }
    }

    // private IEnumerator StartAttacking(Health health)
    // {
    //     yield return new WaitForSeconds(_attackDelay);
    //     health.TakeDamage(_damage);
    //     _comboCounter?.ResetToZero();
    // }

    private void Attack(Health health)
    {
        health.TakeDamage(_damage);
        _comboCounter?.ResetToZero();
    }
}