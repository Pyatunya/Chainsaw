using System;
using System.Collections;
using UnityEngine;

public sealed class LevelTimer : MonoBehaviour
{
    public const float TotalLevelTime = LevelTimeBeforeHard + HardLevelTime;
    private const float LevelTimeBeforeHard = 74f;
    private const float HardLevelTime = 42f;
    
    public bool IsHardLevel { get; private set; }

    public event Action LevelCompleted;
    
    public event Action HardLevelTimeStarted;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(HardLevelTime);
        HardLevelTimeStarted?.Invoke();
        IsHardLevel = true;
        Debug.Log("HardLevel Started");
        
        yield return new WaitForSeconds(LevelTimeBeforeHard);
        LevelCompleted?.Invoke();
        Debug.Log("GameOver");
    }
}