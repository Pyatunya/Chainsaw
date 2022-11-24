using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public sealed class LevelTime : MonoBehaviour
{
    [SerializeField, Min(1f)] private float _levelTime = 30f;
    
    public event UnityAction LevelTimedOut;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_levelTime);
        LevelTimedOut?.Invoke();
    } 
}
