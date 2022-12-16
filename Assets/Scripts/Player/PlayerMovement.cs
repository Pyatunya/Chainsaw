using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Coroutine _addForceRoutine;

    public Vector3 MoveDirection { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveTo(Entity closest, float force)
    {
        Vector3 direction = (closest.transform.position - transform.position).normalized;
        MoveDirection = direction;
        // _rigidbody.AddForce(direction * force);
        AddForce(MoveDirection, force);
    }


    private IEnumerator FakeAddForceMotion(Vector2 direction, float force)
    {
        float dampen = 0.1f;
        float slidingDuration = 0.3f;
        
        float rangeThreshold = 2;
        if (force > rangeThreshold)
        {
            dampen = 0.1f;
            slidingDuration = 1f;
        }

        while (dampen < slidingDuration)
        {
            _rigidbody.velocity = (force / dampen) * direction;
            dampen += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        _rigidbody.velocity = Vector2.zero;
    }


    private void AddForce(Vector2 direction, float force)
    {
        if (_addForceRoutine != null)
            StopCoroutine(_addForceRoutine);

        StartCoroutine(FakeAddForceMotion(direction, force));
    }
}