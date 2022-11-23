using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelTime : MonoBehaviour
{
    [SerializeField, Min(1f)] private float _levelTime = 30f;
    
    public static LevelTime Instance;

    public event UnityAction LevelTimedOut;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_levelTime);
        Debug.Log("GameOver");
        LevelTimedOut?.Invoke();
    } 
}
