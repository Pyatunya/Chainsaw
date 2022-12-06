using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(Rigidbody2D))]
public class ZombieBanshMovement : Entity
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceAttack;
    [SerializeField] private CryFactoroi _cryFactoroi;
    [SerializeField] private float _attackDelay;

    private float _time;
    private Player _player;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (_player.transform.position - transform.position).normalized;

        _rigidbody.MovePosition(direction * _speed * Time.fixedDeltaTime);

        float distance = (_player.transform.position - transform.position).magnitude;

        if (distance >= _distanceAttack && _time >= _attackDelay)
        {
            _cryFactoroi.Create().Throw(direction);
            _time = 0;
        }
    }

    public void Init(Player player)
    {
        _player = player;
    }

    protected override void Enable()
    {

    }
}