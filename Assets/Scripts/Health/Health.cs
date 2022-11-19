using System;
using UnityEngine;

public sealed class Health : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private HealthView _healthView;

    private void OnEnable()
    {
        _healthView.Visualize(_value);
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _value = Mathf.Max(0, _value - damage);
        _healthView.Visualize(_value);
        
        if(_value == 0)
            Die();
    }

    private void Die() => gameObject.SetActive(false);
    
}