using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private float _dashLockTime = 0.5f;
    [SerializeField] private DashSecondsView _dashSecondsView;

    private readonly KeyCode _key = KeyCode.F;
    private Player _player;
    private float _time;
    private bool _isDashCharging = false;

    public event UnityAction DashChargingStarted;
    public event UnityAction DashChargingCompleted;

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
                _player.Attack();
            }

            _time = 0;
        }
    }

    private void ChargeDash()
    {
        _dashSecondsView.Visualize(_time);
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