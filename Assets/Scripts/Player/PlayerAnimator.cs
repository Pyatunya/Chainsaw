using System.Collections;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerDashInput _dashInput;
    [SerializeField] private Player _player;
    // private bool _isAttackingAnimation;

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
        _animator.Play("ChargeIntro", -1, 0);
    }

    private void OnDashChargingCompleted()
    {
        _animator.SetTrigger("ChargeCompleted");
    }

    private void OnAttacked()
    {
        _animator.Play("AttackPlayer", -1, 0);
        // if (_isAttackingAnimation == false)
        // {
        //     _isAttackingAnimation = true;
        //     StartCoroutine(WaitAttackAnimDelay());
        // }
    }

    // private IEnumerator WaitAttackAnimDelay()
    // {
    //     float time = 0.5f;
    //     yield return new WaitForSeconds(time);
    //     _isAttackingAnimation = false;
    // }
}