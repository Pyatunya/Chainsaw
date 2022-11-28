using System;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IEntity
{
    [SerializeField, Min(1)] private int _addScoreCount = 25;
    private IScore _score;
    
    public IComboCounter ComboCounter { get; private set; }
    
    [field: SerializeField] public Health Health { get; private set; }

    private void OnEnable()
    {
        Health.OnDied += OnDied;
        Enable();
    }

    protected abstract void Enable();

    public void Init(IScore score, IComboCounter comboCounter)
    {
        if(_score != null)
            return;

        ComboCounter = comboCounter ?? throw new ArgumentNullException(nameof(comboCounter));
        _score = score ?? throw new ArgumentNullException(nameof(score));
    }

    private void OnDied()
    {
        ComboCounter?.Increase();
        _score?.Add(_addScoreCount);
        gameObject.SetActive(false);
        Health.OnDied -= OnDied;
    }
}