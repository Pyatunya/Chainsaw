using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DashForceView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInputController _playerInputController;

    private Coroutine _chargingUpRoutine;
    private Coroutine _chargingDownRoutine;

    private void OnEnable()
    {
        _slider.value = 0f;
        _playerInputController.DashChargingStarted += OnDashChargingStarted;
        _playerInputController.DashChargingCompleted += OnDashChargingCompleted;
    }

    private void OnDisable()
    {
        _playerInputController.DashChargingStarted -= OnDashChargingStarted;
        _playerInputController.DashChargingCompleted -= OnDashChargingCompleted;
    }

    private IEnumerator ChargingUp()
    {
        float time = 0f;
        while (time <= _player.MaxTimeForDashForce)
        {
            time += Time.deltaTime;
            _slider.value = Mathf.Min(time, _player.MaxTimeForDashForce) / _player.MaxTimeForDashForce;
            yield return null;
        }
    }

    private IEnumerator ChargingDown()
    {
        float rate = 3f;
        while (_slider.value > 0)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, 0, rate * Time.deltaTime);
            yield return null;
        }
    }

    private void OnDashChargingStarted()
    {
        if (_chargingDownRoutine != null)
            StopCoroutine(_chargingDownRoutine);

        _chargingUpRoutine = StartCoroutine(ChargingUp());
    }

    private void OnDashChargingCompleted()
    {
        if (_chargingUpRoutine != null)
            StopCoroutine(_chargingUpRoutine);

        _chargingDownRoutine = StartCoroutine(ChargingDown());
    }
}