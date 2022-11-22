using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class ShoppingCart : MonoBehaviour, IShoppingCart
{
    [SerializeField] private CountView _view;
    private readonly List<IUpgradeView> _upgrades = new();

    public int Price => _upgrades.Sum(upgrade => upgrade.Data.Price);
    
    public void Add(IUpgradeView view)
    {
        if (view == null)
            throw new ArgumentNullException(nameof(view));
        
        _upgrades.Add(view);
        _view.Visualize(Price);
    }
    
    public void Remove(IUpgradeView view)
    {
        if (_upgrades.Contains(view) == false)
            throw new InvalidOperationException("Shopping Cart doesn't contain this view!");
        
        if (view == null)
            throw new ArgumentNullException(nameof(view));
        
        _upgrades.Remove(view);
        _view.Visualize(Price);
    }
}