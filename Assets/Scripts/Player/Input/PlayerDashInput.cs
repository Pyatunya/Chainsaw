using System;
using UnityEngine;

public sealed class PlayerDashInput : PlayerChargingAttackInput
{
    private const float DashLockTime = 0.5f;
    private KeyCode _key;
    private float _time;
    private bool _isDashCharging;

    public event Action DashChargingStarted;
    public event Action DashChargingCompleted;

    public override bool IsCharging => _isDashCharging;

    public void Init(KeyCode key) => _key = key;
    
    private void Update() => ChargeDash();

    private void ChargeDash()
    {
        if (Input.GetKey(_key))
        {
            _time += Time.deltaTime;
            if (_time > DashLockTime && _isDashCharging == false)
            {
                _isDashCharging = true;
                DashChargingStarted?.Invoke();
            }
        }

        if (Input.GetKeyUp(_key))
        {
            if (_isDashCharging)
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