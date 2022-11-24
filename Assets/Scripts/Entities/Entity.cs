using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField, Min(1)] private int _addScoreCount = 25;
    private ComboCounter _comboCounter;
    private IScore _score;
    
    [field: SerializeField] public Health Health { get; private set; }

    protected virtual void OnEnable()
    {
        _comboCounter = FindObjectOfType<ComboCounter>();
        Health.OnDied += OnDied;
    }

    public void Init(IScore score)
    {
        if(_score != null)
            return;
        
        _score = score ?? throw new ArgumentNullException(nameof(score));
    }

    private void OnDisable() => Health.OnDied -= OnDied;

    private void OnDied()
    {
        _comboCounter.Increase();
        _score?.Add(_addScoreCount);
        gameObject.SetActive(false);
    }
}