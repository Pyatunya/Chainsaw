using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private float _dashLockTime = 0.5f;

    private readonly KeyCode _key = KeyCode.F;
    private Player _player;
    private float _time;
    private bool _isDashCharging;

    public event Action DashChargingStarted;
    public event Action DashChargingCompleted;
    public event Action Attacked;

    private void Awake() => _player = GetComponent<Player>();

    private void Update()
    {
        ChargeDash();

        if (Input.GetKeyUp(_key))
        {
            if (_isDashCharging)
            {
                _isDashCharging = false;
                DashChargingCompleted?.Invoke();
                float chargingTimeForDashForce = _time - _dashLockTime;
                _player.Dash(chargingTimeForDashForce);
            }
            else
            {
                Attacked?.Invoke();
                _player.Attack();
            }

            _time = 0;
        }
    }

    private void ChargeDash()
    {
        if (Input.GetKey(_key))
        {
            _time += Time.deltaTime;
            if (_time > _dashLockTime && _isDashCharging == false)
            {
                _isDashCharging = true;
                DashChargingStarted?.Invoke();
            }
        }
    }
}