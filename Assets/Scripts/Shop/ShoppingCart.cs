using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class ShoppingCart : MonoBehaviour
{
    [SerializeField] private CountView _view;
    private List<UpgradeViewData> _data;

    public int Price => _data.Sum(data => data.Price);
    
    public void Add(UpgradeViewData viewData)
    {
        if (viewData == null)
            throw new ArgumentNullException(nameof(viewData));
        
        _data.Add(viewData);
        _view.Visualize(Price);
    }
    
    public void Remove(UpgradeViewData viewData)
    {
        if (_data.Contains(viewData))
            throw new InvalidOperationException("Already contains this data!");
        
        if (viewData == null)
            throw new ArgumentNullException(nameof(viewData));
        
        _data.Remove(viewData);
        _view.Visualize(Price);
    }
}