using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TargetSearcher))]
public class Player : Entity
{
    [SerializeField] private float _moveForce = 300f;

    private TargetSearcher _targetSearcher;
    private Rigidbody2D _playerRB;

    private void Awake()
    {
        _playerRB = GetComponent<Rigidbody2D>();
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

        Vector3 direction = (closest.transform.position - transform.position).normalized;
        _playerRB.AddForce(direction * _moveForce);
    }

    public void Dash()
    {
        if (_targetSearcher.TryFindTarget(out Entity closest))
            MoveTo(closest);
    }
}