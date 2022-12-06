using UnityEngine;

public class Cry : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _force;

    public void Throw(Vector2 direction)
    {
        _rigidbody.AddForce(direction * _force);
    }
}
