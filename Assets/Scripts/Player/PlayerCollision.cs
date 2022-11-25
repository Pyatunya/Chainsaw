using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Player))]
public sealed class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Player _player;
    private int _damage = 1;

    private void OnEnable()
    {
        var storage = new StorageWithNameSaveObject<PlayerCollision, int>();
        _damage = storage.HasSave() ? storage.Load() : 1;
    }

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
        _player.IsAttacking = false;
    }
}