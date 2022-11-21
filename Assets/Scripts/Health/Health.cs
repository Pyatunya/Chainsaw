using System;
using UnityEngine;

public sealed class Health : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private HealthView _healthView;

    private int _maxValue;

    public event Action OnDied;

    private void Start()
    {
        _maxValue = _value;
    }

    private void OnEnable() => _healthView.Visualize(_value);

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _value = Mathf.Max(0, _value - damage);
        _healthView.Visualize(_value);

        if (_value == 0)
            Die();
    }

    private void Die()
    {
        OnDied?.Invoke();
        gameObject.SetActive(false);
    }
}