using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Player))]
public sealed class PlayerAttackInput : MonoBehaviour
{
    [SerializeField] private PlayerChargingAttackInput[] _playerChargingAttackInputs;
    [SerializeField, Min(0.01f)] private float _attackCooldown = 0.3f;
    
    private const KeyCode Key = KeyCode.F;
    private Player _player;
    private bool _isDashCharging;
    private float _time;

    private void Awake() => _player = GetComponent<Player>();

    private void Update()
    {
        _time += Time.deltaTime;
        
        if (Input.GetKeyUp(Key) && _time >= _attackCooldown)
        {
            if (_playerChargingAttackInputs.All(input => input.IsCharging == false))
            {
                _time = 0;
                _player.Attack();
            }
        }
    }
}