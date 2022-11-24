using System;
using UnityEngine;

public sealed class Health : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private HealthView _healthView;
    [SerializeField] private bool _isPlayer;
    
    private int _maxValue;

    public event Action OnDied;

    private void Awake()
    {
        _maxValue = _value;
        
        if(_isPlayer)
        {
            var storage = new StorageWithNameSaveObject<Health, int>();
            _maxValue = storage.HasSave() ? storage.Load() : _maxValue;
        }
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

        if (_value == 0)
            Die();
    }

    private void Die()
    {
        OnDied?.Invoke();
        gameObject.SetActive(false);
    }
}