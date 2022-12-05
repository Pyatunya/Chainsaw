using System;
using System.Collections;
using UnityEngine;

public sealed class LevelTimer : MonoBehaviour
{
    public const float TotalLevelTime = LevelTimeBeforeHard + HardLevelTime;
    private const float LevelTimeBeforeHard = 74f;
    private const float HardLevelTime = 42f;
    private float _time;
    
    [field: SerializeField] public float TimeToEnd { get; private set; } = 114f;
    
    public event Action LevelCompleted;

    public event Action HardLevelTimeStarted;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= HardLevelTime)
        {
            HardLevelTimeStarted?.Invoke();
        }
        
        if (_time >= TimeToEnd)
        {
            LevelCompleted?.Invoke();
        }
    }

    public float GetSpeedFromCurrentTime()
    {
        return Mathf.Min(_time, 10f);
    }
}