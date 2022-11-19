using UnityEngine;

[RequireComponent(typeof(Camera))]
public sealed class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _moveSpeed = 1f;

    private Transform PlayerTransform => _player.transform;

    private void LateUpdate()
    {
        var nextPosition = Vector3.Lerp(transform.position, PlayerTransform.position, _moveSpeed * Time.deltaTime);
        nextPosition.z = -10;
        transform.position = nextPosition;
    }
}