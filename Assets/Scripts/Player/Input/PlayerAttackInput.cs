using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Player))]
public sealed class PlayerAttackInput : MonoBehaviour
{
    [SerializeField] private PlayerChargingAttackInput[] _playerChargingAttackInputs;
    private const KeyCode Key = KeyCode.F;

    private Player _player;
    private bool _isDashCharging;

    private void Awake() => _player = GetComponent<Player>();

    private void Update()
    {
        if (Input.GetKeyUp(Key))
        {
            if (_playerChargingAttackInputs.All(input => input.IsCharging == false))
            {
                _player.Attack();
            }
        }
    }
}