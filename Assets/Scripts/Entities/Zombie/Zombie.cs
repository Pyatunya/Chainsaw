using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class Zombie : Entity
{
    [SerializeField] private float _speed = 1f;
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody;

    public override Vector2 MoveDirection => _moveDirection;
    
    public Player Player { get; private set; }
    
    public void Init(Player player)
    {
        // if (speed <= 0) 
        //     throw new ArgumentOutOfRangeException(nameof(speed));
        
        Player = player ?? throw new ArgumentNullException(nameof(player));
    }

    private void Start()
    {
        _rigidbody ??= GetComponent<Rigidbody2D>();
    }
    

    private void FixedUpdate()
    {
        if (Player == null || CanMove == false)
            return;

        Vector2 direction = (Player.transform.position - transform.position).normalized;
        _moveDirection = direction;
        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.fixedDeltaTime);
    }


    protected override void Enable()
    {
        
    }
}