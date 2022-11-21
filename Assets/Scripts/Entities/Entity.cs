using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField, Min(1)] private int _addSCount = 25;
    private IScore _score;
    private ComboCounter _comboCounter;
    
    public void Init(IScore score)
    {
        _comboCounter = FindObjectOfType<ComboCounter>();
        _score = score ?? throw new ArgumentNullException(nameof(score));
        _health.OnDied += OnDied;
    }

    private void OnDisable()
    {
        if (_health != null)
            _health.OnDied -= OnDied;
    }

    private void OnDied()
    {
        _comboCounter?.Increase();
        _score.Add(_addSCount);
        gameObject.SetActive(false);
    }
}