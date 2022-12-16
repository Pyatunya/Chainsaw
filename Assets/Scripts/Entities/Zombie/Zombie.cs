using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class Zombie : Entity
{
    private float _speed = 4f;
    private Rigidbody2D _rigidbody;
    private Player _player;
    
    public bool CanMove { get; private set; }

    public Vector2 MoveDirection { get; private set; }
    
    public void Init(Player player, float speed)
    {
        if (speed <= 0) 
            throw new ArgumentOutOfRangeException(nameof(speed));
        
        _player = player ?? throw new ArgumentNullException(nameof(player));
        _speed = speed;
    }

    private void Start()
    {
        _rigidbody ??= GetComponent<Rigidbody2D>();
    }
    
    public void StopMovement() => CanMove = false;

    public void ContinueMovement() => CanMove = true;

    private void FixedUpdate()
    {
        if (_player == null || CanMove == false || _rigidbody.bodyType == RigidbodyType2D.Static)
            return;

        Vector2 direction = (_player.transform.position - transform.position).normalized;
        MoveDirection = direction;
        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.fixedDeltaTime);
    }

    protected override void Enable()
    {
        
    }
}