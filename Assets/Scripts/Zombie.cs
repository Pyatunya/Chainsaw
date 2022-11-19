using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Zombie : Entity
{
    [SerializeField, Min(0.1f)] private float _speed = 1.4f;
    private Player _player;
    
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody ??= GetComponent<Rigidbody2D>();
        _player ??= FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = (_player.transform.position - transform.position).normalized;
        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.fixedDeltaTime);
    }
}