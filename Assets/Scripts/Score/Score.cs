using System;
using UnityEngine;

public sealed class Score : MonoBehaviour, IScore
{
    [SerializeField] private CountView _view;
    private int _count;

    public event Action<int> OnChanged;
    
    public void Add(int count)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        _count += count;
        _view.Visualize(_count);
        OnChanged?.Invoke(_count);
    }
}