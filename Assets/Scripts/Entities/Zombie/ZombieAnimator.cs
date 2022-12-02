using System.Collections;
using UnityEngine;

public sealed class ZombieAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Zombie _zombie;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ZombieCollision _zombieCollision;
    [SerializeField] private Health _health;
    [SerializeField] private string[] _dieAnimationsBoolNames;
    [SerializeField] private Sprite _dieSprite;
    
    private bool _isWalkingRight;
    private bool _isWalkingUp;
    private readonly int _zombieAttack = Animator.StringToHash("ZombieAttack");

    private void OnEnable()
    {
        _zombieCollision.OnAttacked += OnAttacked;
        _health.OnDied += OnDied;
    }

    private void OnDied() => StartCoroutine(OnDying());

    private IEnumerator OnDying()
    {
        var dieAnimationsBoolName = _dieAnimationsBoolNames[Random.Range(0, _dieAnimationsBoolNames.Length)];
        _animator.SetBool(dieAnimationsBoolName, true);
        _animator.SetBool(_zombieAttack, false);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);
        _animator.enabled = false;
        _spriteRenderer.sprite = _dieSprite;

    }

    private void OnDisable()
    {
        _zombieCollision.OnAttacked -= OnAttacked;
        _health.OnDied -= OnDied;
    }

    private void Update()
    {
        _isWalkingRight = _zombie.MoveDirection.x >= 0;
        _isWalkingUp = _zombie.MoveDirection.y >= 0;
        _spriteRenderer.flipX = _isWalkingRight;
        _animator.SetBool("WalkDiagonal", _isWalkingUp);
        _animator.SetBool("CanMove", _zombie.CanMove);
    }

    private void OnAttacked() => _animator.SetBool(_zombieAttack, true);
    
}