using System;
using System.Linq;
using UnityEngine;

public sealed class PlayerPcAttackInput : IUpdateble
{ 
    private readonly IPlayerChargingAttackInput[] _playerChargingAttackInputs;
    private readonly IPlayer _player;
    private const float AttackCooldown = 0.025f;
    private const KeyCode Key = KeyCode.F;
    private bool _isDashCharging;
    private float _time;

    public PlayerPcAttackInput(IPlayerChargingAttackInput[] playerChargingAttackInputs, IPlayer player)
    {
        _playerChargingAttackInputs = playerChargingAttackInputs ?? throw new ArgumentNullException(nameof(playerChargingAttackInputs));
        _player = player ?? throw new ArgumentNullException(nameof(player));
    }

    public void Update(float deltaTime)
    {
        _time += deltaTime;

        if (Input.GetKeyUp(Key) && _time >= AttackCooldown)
        {
            if (_playerChargingAttackInputs.All(input => input.IsCharging == false))
            {
                _time = 0;
                _player.Attack();
            }
        }
    }
}