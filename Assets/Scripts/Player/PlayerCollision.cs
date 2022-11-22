using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Player))]
public sealed class PlayerCollision : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage = 5;
    [SerializeField] private Player _player;
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health) && _player.IsAttacking)
        { 
            Attack(health);
        }
    }

    private void Attack(Health health)
    {
        health.TakeDamage(_damage);
    }
}