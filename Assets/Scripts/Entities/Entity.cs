using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField, Min(1)] private int _addSCount = 25;
    private IScore _score;

    public void Init(IScore score)
    {
        _score = score ?? throw new ArgumentNullException(nameof(score));
    }

    private void OnDisable()
    {
        _score.Add(_addSCount);
        gameObject.SetActive(false);
    }
}