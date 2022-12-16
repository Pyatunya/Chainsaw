using System.Collections;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerDashInput _dashInput;
    [SerializeField] private Player _player;
    private bool _isAttackingAnimation;
    
    private readonly int _chargeCompletedId = Animator.StringToHash("ChargeCompleted");
    private readonly int _chargeIntroId = Animator.StringToHash("ChargeIntro");
    private readonly int _attackPlayer = Animator.StringToHash("AttackPlayer");

    private void OnEnable()
    {
        _dashInput.DashChargingStarted += OnDashChargingStarted;
        _dashInput.DashChargingCompleted += OnDashChargingCompleted;
        _player.Attacked += OnAttacked;
    }

    private void OnDisable()
    {
        _dashInput.DashChargingStarted -= OnDashChargingStarted;
        _dashInput.DashChargingCompleted -= OnDashChargingCompleted;
        _player.Attacked -= OnAttacked;
    }

    private void Update()
    {
        _spriteRenderer.flipX = _player.Movement.MoveDirection.x >= 0;
    }

    private void OnDashChargingStarted()
    {
        _animator.Play(_chargeIntroId, -1, 0);
    }

    private void OnDashChargingCompleted()
    {
        _animator.SetTrigger(_chargeCompletedId);
    }

    private void OnAttacked()
    {
        if (_isAttackingAnimation == false)
        {
            _isAttackingAnimation = true;
            _animator.Play(_attackPlayer, -1, 0);
            StartCoroutine(WaitAttackAnimDelay());
        }
    }

    private IEnumerator WaitAttackAnimDelay()
    {
        const float time = 0.5f;
        yield return new WaitForSeconds(time);
        _isAttackingAnimation = false;
    }
}