using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class Zombie : Entity
{
    private float _speed = 4f;
    private Rigidbody2D _rigidbody;
    
    public bool CanMove { get; private set; }

    public Vector2 MoveDirection { get; private set; }
    
    public Player Player { get; private set; }
    
    public void Init(Player player, float speed)
    {
        if (speed <= 0) 
            throw new ArgumentOutOfRangeException(nameof(speed));
        
        Player = player ?? throw new ArgumentNullException(nameof(player));
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
        if (Player == null || CanMove == false)
            return;

        Vector2 direction = (Player.transform.position - transform.position).normalized;
        MoveDirection = direction;
        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.fixedDeltaTime);
    }

    protected override void Enable()
    {
        
    }
}