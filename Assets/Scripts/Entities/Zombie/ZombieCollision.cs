using System;
using UnityEngine;

public sealed class ZombieCollision : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private Zombie _zombie;

    private const float AttackDelay = 0.25f;
    private float _inCollisionTime = 0f;

    public event Action OnAttacked;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out GameLose player))
        {
            _zombie.StopMovement();
            _inCollisionTime += Time.deltaTime;

            if (_inCollisionTime > AttackDelay && gameObject.activeSelf)
            {
                Attack(player.Health);
                _inCollisionTime = 0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out GameLose _))
        {
            _inCollisionTime = 0f;
            _zombie.ContinueMovement();
        }
    }

    private void Attack(Health health)
    {
        OnAttacked?.Invoke();
        health.TakeDamage(_damage);
        _zombie.ComboCounter.ResetToZero();
    }
}