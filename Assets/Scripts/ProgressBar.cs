using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public sealed class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _bar;

    private IEnumerator Start()
    {
        var elapsed = 0f;
        
        while (true)
        {
            yield return null;
            elapsed += Time.deltaTime;
            _bar.fillAmount = Mathf.Lerp(0, 1, elapsed / LevelTimer.LevelTime);
        }
    }
}