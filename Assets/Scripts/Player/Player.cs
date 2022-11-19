using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TargetSearcher))]
public class Player : Entity
{
    [SerializeField] private float _moveForce = 300f;
    [SerializeField] private float _dashForce = 600f;
    
    private TargetSearcher _targetSearcher;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _targetSearcher = GetComponent<TargetSearcher>();
    }

    public void Attack()
    {
        Debug.Log("attack");

        if (_targetSearcher.TryFindTarget(out Entity closest))
            MoveTo(closest, _moveForce);
    }

    private void MoveTo(Entity closest, float force)
    {
        var direction = (closest.transform.position - transform.position).normalized;
        _rigidbody.AddForce(direction * force);
    }

    public void Dash()
    {
        Debug.Log("Dash");
        if (_targetSearcher.TryFindTarget(out Entity closest))
            MoveTo(closest, _dashForce);
    }
}