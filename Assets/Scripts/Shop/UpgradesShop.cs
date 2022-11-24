using System.Collections.Generic;
using UnityEngine;

public sealed class UpgradesShop : MonoBehaviour
{
    [SerializeField] private List<UpgradeHealthViewData> _data;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private UpgradeView _upgradePrefab;
    [SerializeField] private ShoppingCart _shoppingCart;

    private void Start()
    {
        foreach (var data in _data)
        {
            AddHealthUpgrade(data);
        }
    }

    private void AddHealthUpgrade(UpgradeHealthViewData data)
    {
        var upgrade = Instantiate(_upgradePrefab, _itemContainer.transform);
        upgrade.Init(data, new SaveUpgrade<Health, int>(new BinaryStorage(), data.HealthCount, $"{data.Price} {data.HealthCount} {data.Description} {data.FullDescription}"), _shoppingCart);
    }
}