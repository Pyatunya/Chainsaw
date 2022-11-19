using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class EntityCollision : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage = 5;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            if(health.gameObject.layer == gameObject.layer)
                return;
            
            health.TakeDamage(_damage);
            Debug.Log("Damage лоъ");
        }
    }
}