using UnityEngine;

[RequireComponent(typeof(ZombieCollision), typeof(Zombie))]
public sealed class ZombieMovementMotion : MonoBehaviour
{
    [SerializeField] private float _returnMovementDistance = 5f;
    private ZombieCollision _zombieCollision;
    private Zombie _zombie;

    private void Start()
    {
        _zombieCollision = GetComponent<ZombieCollision>();
        _zombie = GetComponent<Zombie>();
        _zombieCollision.OnAttacked += OnAttacked;
    }

    private void OnAttacked() => _zombie.StopMovement();

    private void Update()
    {
        if(_zombie.CanMove)
            return;
        
        var distance = (_zombie.Player.transform.position - transform.position).magnitude;
        
        if(distance >= _returnMovementDistance)
        {
            _zombie.ContinueMovement();
        }
    }
}