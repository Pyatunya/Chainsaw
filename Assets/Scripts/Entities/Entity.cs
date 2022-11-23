using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField, Min(1)] private int _addScoreCount = 25;
    private ComboCounter _comboCounter;
    private IScore _score;

    private void OnEnable() => _health.OnDied += OnDied;

    public void Init(IScore score)
    {
        if(_score != null)
            return;
        
        _comboCounter = FindObjectOfType<ComboCounter>();
        _score = score ?? throw new ArgumentNullException(nameof(score));
    }

    private void OnDisable() => _health.OnDied -= OnDied;

    private void OnDied()
    {
        _comboCounter.Increase();
        _score.Add(_addScoreCount);
        gameObject.SetActive(false);
    }
}