using UnityEngine;

public class DashVfx : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dashChargingVfx;
    [SerializeField] private ParticleSystem _dashTrailVfx;
    [SerializeField] private PlayerInputController _playerInputController;

    private void OnEnable()
    {
        _playerInputController.DashChargingStarted += OnDashChargingStarted;
        _playerInputController.DashChargingCompleted += OnDashChargingCompleted;
    }

    private void OnDisable()
    {
        _playerInputController.DashChargingStarted -= OnDashChargingStarted;
        _playerInputController.DashChargingCompleted -= OnDashChargingCompleted;
    }

    private void OnDashChargingStarted()
    {
        _dashChargingVfx.Play();
    }

    private void OnDashChargingCompleted()
    {
        _dashChargingVfx.Stop();
        _dashTrailVfx.Play();
    }
}