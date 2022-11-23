using System;
using Tools;
using UnityEngine;

public sealed class ComboCounter : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private ComboCounterView _view;
    [SerializeField] private int _countWhenNeedAddNewMoney = 5;
    [SerializeField] private int _addMoney = 10;
    
    private int _value;

    public void Increase()
    {
        _value++;
        _view.Visualize(_value);

        int numberOfWholeDivisions = _value.GetNumberOfWholeDivisions(_countWhenNeedAddNewMoney);
        
        if (numberOfWholeDivisions > 0)
        {
            _wallet.Put(numberOfWholeDivisions * _addMoney);
        }
    }

    public void ResetToZero()
    {
        _value = 0;
        _view.Visualize(_value);
    }
}