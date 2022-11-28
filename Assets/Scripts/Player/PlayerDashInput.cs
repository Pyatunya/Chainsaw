using System;
using UnityEngine;

public sealed class PlayerDashInput : PlayerChargingAttackInput
{
    private const float DashLockTime = 0.5f;
    private const KeyCode Key = KeyCode.F;
    private float _time;
    private bool _isDashCharging;

    public event Action DashChargingStarted;

    public event Action DashChargingCompleted;

    public override bool IsCharging => _isDashCharging;

    private void Update()
    {
        ChargeDash();
    }

    private void ChargeDash()
    {
        if (Input.GetKey(Key))
        {
            _time += Time.deltaTime;
            if (_time > DashLockTime && _isDashCharging == false)
            {
                _isDashCharging = true;
                DashChargingStarted?.Invoke();
            }
        }

        if (Input.GetKeyUp(Key) && _isDashCharging)
        {
            Dash();
            _time = 0;
        }
    }

    private void Dash()
    {
        _isDashCharging = false;
        DashChargingCompleted?.Invoke();
        float chargingTimeForDashForce = _time - DashLockTime;
        Player.Dash(chargingTimeForDashForce);
    }
}