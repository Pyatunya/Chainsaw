using UnityEngine;

public sealed class ComboCounter : MonoBehaviour
{
    [SerializeField] private CountView _view;
    private int _value;

    public void Increase()
    {
        _value++;
        _view.Visualize(_value);
    }

    public void ResetToZero()
    {
        _value = 0;
        _view.Visualize(_value);
    }
}