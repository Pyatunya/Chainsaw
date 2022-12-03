using System;
using UnityEngine;

public sealed class LevelTimer : MonoBehaviour
{
    [SerializeField] private bool _needEnd;

    [field: SerializeField] public float TimeToEnd { get; private set; } = 114f;
    
    public float Time { get; private set; }

    public event Action LevelCompleted;
    
    private void Update()
    {
        Time += UnityEngine.Time.deltaTime;

        if (_needEnd && Time >= TimeToEnd)
        {
            LevelCompleted?.Invoke();
        }
    }

    // public float GetSpeedFromCurrentTime()
    // {
    //     return Mathf.Min(Time, 10f);
    // }
}