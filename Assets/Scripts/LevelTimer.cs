using System;
using System.Collections;
using UnityEngine;

public sealed class LevelTimer : MonoBehaviour
{
    public const float TotalLevelTime = LevelTimeBeforeHard + HardLevelTime;
    private const float LevelTimeBeforeHard = 74f;
    private const float HardLevelTime = 42f;
    
    public float Time1 { get; private set; }

    [field: SerializeField] public float TimeToEnd { get; private set; } = 114f;
    
    public event Action LevelCompleted;

    public event Action HardLevelTimeStarted;

    private void Update()
    {
        Time1 += UnityEngine.Time.deltaTime;

        if (Time1 >= HardLevelTime)
        {
            HardLevelTimeStarted?.Invoke();
        }
        
        if (Time1 >= TimeToEnd)
        {
            LevelCompleted?.Invoke();
        }
    }

    public float GetSpeedFromCurrentTime()
    {
        return Mathf.Min(Time1, 10f);
    }
}