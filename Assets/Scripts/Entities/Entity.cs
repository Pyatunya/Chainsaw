using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField, Min(1)] private int _addScoreCount = 25;
    private IScore _score;

    public void Init(IScore score)
    {
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
        _score.Add(_addScoreCount);
        gameObject.SetActive(false);
    }
}