using UnityEngine;

public class DashVfx : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dashChargingVfx;
    [SerializeField] private PlayerInputController _playerInputController;

    private void OnEnable()
    {
        _playerInputController.DashChargingStarted += OnDashChargingStarted;
        _playerInputController.DashChargingEnded += OnDashChargingEnded;
    }

    private void OnDisable()
    {
        _playerInputController.DashChargingStarted -= OnDashChargingStarted;
        _playerInputController.DashChargingEnded -= OnDashChargingEnded;
    }

    private void OnDashChargingStarted()
    {
        _dashChargingVfx.Play();
    }

    private void OnDashChargingEnded()
    {
        _dashChargingVfx.Stop();
    }
}