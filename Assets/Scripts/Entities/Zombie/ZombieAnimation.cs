using UnityEngine;

public sealed class ZombieAnimation : MonoBehaviour
{
    [SerializeField] private Zombie _zombie;
    [SerializeField] private ZombieCollision _zombieCollision;

    private bool _hasStopped;

    private readonly int _zombieAttack = Animator.StringToHash("ZombieAttack");
    private readonly int _canMove = Animator.StringToHash("CanMove");
    private readonly int _walkDiagonal = Animator.StringToHash("WalkDiagonal");

    [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
    
    [field: SerializeField] public Animator Animator { get; private set; }

    private void OnEnable() => _zombieCollision.OnAttacked += OnAttacked;

    private void OnDisable() => _zombieCollision.OnAttacked -= OnAttacked;

    private void Update()
    {
        if(_hasStopped)
            return;

        var isWalkingRight = _zombie.MoveDirection.x >= 0;
        var isWalkingUp = _zombie.MoveDirection.y >= 0;
        SpriteRenderer.flipX = isWalkingRight;
        Animator.SetBool(_walkDiagonal, isWalkingUp);
        Animator.SetBool(_canMove, _zombie.CanMove);
    }

    public void StopAll()
    {
        _hasStopped = true;
        Animator.SetBool(_walkDiagonal, false);
        Animator.SetBool(_canMove, false);
        Animator.SetBool(_zombieAttack, false);
    }
    
    private void OnAttacked()
    {
        if(_hasStopped)
            return;
        
        Animator.SetBool(_zombieAttack, true);
    }

    public void Enable() => _hasStopped = false;
    
}