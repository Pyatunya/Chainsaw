using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public sealed class LevelTimer : MonoBehaviour
{
    public const float LevelTime = 74f;
    private const float HardLevelTime = 42f;
    
    public bool IsHardLevel { get; private set; }

    public event UnityAction LevelCompleted;
    
    public event UnityAction HardLevelTimeStarted;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(HardLevelTime);
        HardLevelTimeStarted?.Invoke();
        IsHardLevel = true;
        Debug.Log("HardLevel Started");
        
        yield return new WaitForSeconds(LevelTime);
        LevelCompleted?.Invoke();
        Debug.Log("GameOver");
    }
}