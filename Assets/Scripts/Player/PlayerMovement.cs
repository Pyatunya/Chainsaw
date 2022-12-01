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
<<<<<<< HEAD

    public void DashTo(Entity closest, float force)
    {
        MoveDirection = CalculateDirectionTo(closest.transform);
        _rigidbody.AddForce(MoveDirection * force);
    }

    public void MoveTo(Entity closest)
    {
        MoveDirection = CalculateDirectionTo(closest.transform);
        MovingTo(closest.transform).Forget();
    }

    private Vector2 CalculateDirectionTo(Transform closest)
    {
        return (closest.position - transform.position).normalized;
    }

    private async UniTaskVoid MovingTo(Transform closest)
    {
        var time = 0f;
        var position = _rigidbody.transform.position;
        var distance = (closest.position - transform.position).magnitude;
        var timeToReachEntity = distance <= 8.5f ? _timeToReachEntity : _timeToReachEntity * 1.5f;
        
        while (time <= _timeToReachEntity)
        {
            time += Time.deltaTime;
            _rigidbody.transform.position = Vector2.Lerp(position, closest.position, time / timeToReachEntity);
            await Task.Yield();
        }
=======
    
    public void MoveTo(Entity closest, float force)
    {
        Vector3 direction = (closest.transform.position - transform.position).normalized;
        MoveDirection = direction;
        _rigidbody.AddForce(direction * force);
>>>>>>> parent of 55d01c8 (New Movement Done)
    }
}