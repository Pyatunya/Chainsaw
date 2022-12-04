using System;
using UnityEngine;

public sealed class Health : MonoBehaviour
{
    [SerializeField, Min(1)] private int _value;
    [SerializeField] private HealthView _healthView;
    
    private int _maxValue;

    public event Action OnDied;

    public event Action OnDamaged;
    
    private void Awake() => _maxValue = _value;

    public void Init(int maxValue)
    {
        if (maxValue <= 0) 
            throw new ArgumentOutOfRangeException(nameof(maxValue));
        
        _maxValue = maxValue;
    }

    public void Heal()
    {
        _value = _maxValue;
        _healthView.Visualize(_value, _maxValue);
    }

    private void OnEnable()
    {
        if (_maxValue != 0)
            _value = _maxValue;
        
        _healthView.Visualize(_value, _maxValue);
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _value = Mathf.Max(0, _value - damage);
        _healthView.Visualize(_value, _maxValue);
        OnDamaged?.Invoke();

        if (_value == 0) 
            OnDied?.Invoke();
    }
}