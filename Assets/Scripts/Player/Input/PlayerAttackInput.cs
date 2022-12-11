using System;
using System.Linq;
using UnityEngine;

public sealed class PlayerAttackInput : IUpdateble
{ 
    private readonly IPlayerChargingAttackInput[] _playerChargingAttackInputs;
    private readonly IPlayer _player;
    private readonly KeyCode _key;
    private bool _isDashCharging;
    private const float AttackCooldown = 0.025f;
    private float _time;

    public PlayerAttackInput(IPlayerChargingAttackInput[] playerChargingAttackInputs, IPlayer player, KeyCode keyCode)
    {
        _playerChargingAttackInputs = playerChargingAttackInputs ?? throw new ArgumentNullException(nameof(playerChargingAttackInputs));
        _player = player ?? throw new ArgumentNullException(nameof(player));
        _key = keyCode;
    }

    public void Update(float deltaTime)
    {
        _time += deltaTime;

        if (Input.GetKeyUp(_key) && _time >= AttackCooldown)
        {
            if (_playerChargingAttackInputs.All(input => input.IsCharging == false))
            {
                _time = 0;
                _player.Attack();
            }
        }
    }
}