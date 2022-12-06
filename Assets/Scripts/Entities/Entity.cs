using System;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IEntity
{
    [SerializeField, Min(1)] private int _addScoreCount = 25;
    private IScore _score;
    
    public IComboCounter ComboCounter { get; private set; }
    
    public abstract Vector2 MoveDirection { get; }

    public bool CanMove { get; private set; } = true;
    
    [field: SerializeField] public Health Health { get; private set; }

    private void OnEnable()
    {
        Health.OnDied += OnDied;
        Enable();
    }

    public void StopMovement() => CanMove = false;
    
    public void ContinueMovement() => CanMove = true;

    
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
        Health.OnDied -= OnDied;
    }

}