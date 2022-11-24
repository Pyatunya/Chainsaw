using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float _levelTime = 74f;
    [SerializeField] private float _difficultTime = 42f;

    public bool IsDifficultPhase = false;

    public event UnityAction LevelDifficultIncreased;
    public event UnityAction LevelCompleted;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_difficultTime);
        LevelDifficultIncreased?.Invoke();
        IsDifficultPhase = true;
        Debug.Log("Difficult Start");
        yield return new WaitForSeconds(_levelTime);
        LevelCompleted?.Invoke();
    }
}