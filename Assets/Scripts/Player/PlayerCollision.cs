using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Player))]
public sealed class PlayerCollision : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage = 5;
    [SerializeField] private Player _player;
    private float _time;
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health) && _player.IsAttacking && _time >= 0.4f)
        { 
            Attack(health);
        }
    }

    private void Update() => _time += Time.deltaTime;

    private void Attack(Health health)
    {
        _time = 0;
        health.TakeDamage(_damage);
    }
}