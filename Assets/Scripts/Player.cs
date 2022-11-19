using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TargetSearcher))]
public class Player : Entity
{
    [SerializeField] private float _moveForce;

    private TargetSearcher _targetSearcher;
    private Rigidbody2D playerRB;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        _targetSearcher = GetComponent<TargetSearcher>();
    }

    public void Attack()
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
            MoveTo(closest);
    }

    private void MoveTo(Entity closest)
    {
        if (closest == null)
            return;

        Vector3 direction = (closest.transform.position - transform.position);
        playerRB.AddForce(direction * _moveForce);
    }

    public void Dash()
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
            MoveTo(closest);
    }
}
