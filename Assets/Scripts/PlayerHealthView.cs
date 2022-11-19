using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerHealthView : HealthView
{
    [SerializeField] private Scrollbar _scrollbar;
    
    public override void Visualize(int value)
    {
        _scrollbar.size = value / 100f;
    }
}