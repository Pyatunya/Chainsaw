using System.Collections;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerInputController _inputController;
    [SerializeField] private Player _player;

    private bool _isAttackingAnimation = false;

    private void OnEnable()
    {
        _inputController.DashChargingStarted += OnDashChargingStarted;
        _inputController.DashChargingCompleted += OnDashChargingCompleted;
        _inputController.Attacked += OnAttacked;
    }

    private void OnDisable()
    {
        _inputController.DashChargingStarted -= OnDashChargingStarted;
        _inputController.DashChargingCompleted -= OnDashChargingCompleted;
        _inputController.Attacked -= OnAttacked;
    }

    private void Update()
    {
        _spriteRenderer.flipX = _player.MoveDirection.x >= 0;
    }

    private void OnDashChargingStarted()
    {
        _animator.Play("ChargeIntro", -1, 0);
    }

    private void OnDashChargingCompleted()
    {
        _animator.SetTrigger("ChargeCompleted");
    }

    private void OnAttacked()
    {
        if (_isAttackingAnimation == false)
        {
            _isAttackingAnimation = true;
            _animator.Play("AttackPlayer", -1, 0);
            StartCoroutine(WaitAttackAnimDelay());
        }
    }

    private IEnumerator WaitAttackAnimDelay()
    {
        float time = 0.5f;
        yield return new WaitForSeconds(time);
        _isAttackingAnimation = false;
    }
}