using System;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField, Min(1)] private int _addScoreCount = 25;
    private ComboCounter _comboCounter;
    private IScore _score;
    
    [field: SerializeField] public Health Health { get; private set; }

    protected void OnEnable()
    {
        _comboCounter = FindObjectOfType<ComboCounter>();
        Health.OnDied += OnDied;
        Enable();
    }

    protected abstract void Enable();

    public void Init(IScore score)
    {
        if(_score != null)
            return;
        
        _score = score ?? throw new ArgumentNullException(nameof(score));
    }

    private void OnDied()
    {
        _comboCounter.Increase();
        _score?.Add(_addScoreCount);
        gameObject.SetActive(false);
        Health.OnDied -= OnDied;
    }
}