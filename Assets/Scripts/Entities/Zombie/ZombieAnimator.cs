using UnityEngine;

public sealed class ZombieAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Zombie _zombie;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ZombieCollision _zombieCollision;

    private bool _isWalkingRight;
    private bool _isWalkingUp;

    private void OnEnable()
    {
        _zombieCollision.OnAttacked += OnAttacked;
    }

    private void OnDisable()
    {
        _zombieCollision.OnAttacked -= OnAttacked;
    }

    private void Update()
    {
        _isWalkingRight = _zombie.MoveDirection.x >= 0;
        _isWalkingUp = _zombie.MoveDirection.y >= 0;

        _spriteRenderer.flipX = _isWalkingRight;

        _animator.SetBool("WalkDiagonal", _isWalkingUp);
        _animator.SetBool("CanMove", _zombie.CanMove);
    }

    private void OnAttacked()
    {
        _animator.Play("ZombieAttack", -1, 0);
    }
}