using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TargetSearcher))]
public class Player : Entity
{
    private TargetSearcher _targetSearcher;
    private Rigidbody2D playerRB;
    private float _moveForce;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        _targetSearcher = GetComponent<TargetSearcher>();
    }

    public void Attack()
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
        {
            MoveTo(closest);
        }
    }

    private void MoveTo(Entity closest)
    {
        Vector3 direction = (closest.transform.position - transform.position).normalized;
        playerRB.AddForce(direction * _moveForce, ForceMode2D.Impulse);
    }

    public void Dash()
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
        {
            MoveTo(closest);
        }
    }
}
