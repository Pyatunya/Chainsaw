using UnityEngine;

public sealed class DashVfx : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dashChargingVfx;
    [SerializeField] private ParticleSystem _dashTrailVfx;
    [SerializeField] private PlayerDashInput _playerDashInput;

    private void OnEnable()
    {
        _playerDashInput.DashChargingStarted += OnDashChargingStarted;
        _playerDashInput.DashChargingCompleted += OnDashChargingCompleted;
    }

    private void OnDisable()
    {
        _playerDashInput.DashChargingStarted -= OnDashChargingStarted;
        _playerDashInput.DashChargingCompleted -= OnDashChargingCompleted;
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