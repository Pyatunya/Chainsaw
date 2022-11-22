using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerHealthView : HealthView
{
    [SerializeField] private Slider _slider;
    
    public override void Visualize(int value, int maxValue)
    {
        _slider.value = (float)value / maxValue;
    }
}