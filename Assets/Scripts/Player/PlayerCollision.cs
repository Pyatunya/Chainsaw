using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class PlayerCollision : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage = 5;
    [SerializeField] private ComboCounter _comboCounter;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        { 
            Attack(health);
        }
    }

    private void Attack(Health health)
    {
        health.TakeDamage(_damage);
        _comboCounter?.Increase();
    }
}