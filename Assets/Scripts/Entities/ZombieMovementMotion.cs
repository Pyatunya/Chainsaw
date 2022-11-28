using UnityEngine;

[RequireComponent(typeof(ZombieCollision), typeof(Zombie))]
public sealed class ZombieMovementMotion : MonoBehaviour
{
    [SerializeField] private float _returnMovementDistance = 5f;
    private ZombieCollision _zombieCollision;
    private Zombie _zombie;
    private Transform _player;

    private void Start()
    {
        _zombieCollision = GetComponent<ZombieCollision>();
        _zombie = GetComponent<Zombie>();
        _player = FindObjectOfType<Player>().gameObject.transform;
        _zombieCollision.OnAttacked += OnAttacked;
    }

    private void OnAttacked() => _zombie.StopMovement();

    private void Update()
    {
        if(_zombie.CanMove)
            return;
        
        var distance = (_player.position - transform.position).magnitude;
        
        if(distance >= _returnMovementDistance)
        {
            _zombie.ContinueMovement();
        }
    }
}