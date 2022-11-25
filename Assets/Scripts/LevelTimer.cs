using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public sealed class LevelTimer : MonoBehaviour
{
    private readonly float _hardLevelTime = 42f;
    private readonly float _levelTime = 74f;
    
    public bool IsHardLevel { get; private set; }

    public event UnityAction LevelCompleted;
    
    public event UnityAction HardLevelTimeStarted;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_hardLevelTime);
        HardLevelTimeStarted?.Invoke();
        IsHardLevel = true;
        Debug.Log("HardLevel Started");
        
        yield return new WaitForSeconds(_levelTime);
        LevelCompleted?.Invoke();
        Debug.Log("GameOver");
    }
}