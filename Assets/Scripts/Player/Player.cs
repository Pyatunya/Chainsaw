using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TargetSearcher))]
public class Player : Entity
{
    [SerializeField] private float _moveForce = 300f;

    private TargetSearcher _targetSearcher;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _targetSearcher = GetComponent<TargetSearcher>();
    }

    public void Attack()
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
            MoveTo(closest);
    }

    private void MoveTo(Entity closest)
    {
        var direction = (closest.transform.position - transform.position).normalized;
        _rigidbody.AddForce(direction * _moveForce);
    }

    public void Dash()
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
            MoveTo(closest);
    }
}