using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public Vector3 MoveDirection { get; private set; }
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void MoveTo(Entity closest, float force)
    {
        Vector3 direction = (closest.transform.position - transform.position).normalized;
        MoveDirection = direction;
        _rigidbody.AddForce(direction * force);
    }
}