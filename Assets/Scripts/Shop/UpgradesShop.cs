using System.Collections.Generic;
using UnityEngine;

public class UpgradesShop : MonoBehaviour
{
    [SerializeField] private List<UpgradeViewData> _data;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private UpgradeView _upgradePrefab;
    [SerializeField] private ShoppingCart _shoppingCart;

    private void Start()
    {
        foreach (var data in _data)
        {
            AddItem(data);
        }
    }

    private void AddItem(UpgradeViewData data)
    {
        var upgrade = Instantiate(_upgradePrefab, _itemContainer.transform);
        upgrade.Init(data, new NullUpgrade(), _shoppingCart);
    }
}

public sealed class NullUpgrade : IUpgrade
{
    public bool HasUsed { get; private set; }

    public void Use()
    {
        HasUsed = true;
    }
}
