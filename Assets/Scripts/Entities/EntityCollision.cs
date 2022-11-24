using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class EntityCollision : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage = 5;

    private ComboCounter _comboCounter;
    private float _attackDelay = 0.3f;
    private float _collisionTime = 0f;

    private void OnEnable() => _comboCounter = FindObjectOfType<ComboCounter>();

    private void OnTriggerStay2D(Collider2D collision)
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth _))
        {
            _collisionTime = 0f;
        }
    }

    private void Attack(Health health)
    {
        health.TakeDamage(_damage);
        _comboCounter.ResetToZero();
    }
}