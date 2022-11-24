using System.Collections.Generic;
using UnityEngine;

public sealed class UpgradesShop : MonoBehaviour
{
    [SerializeField] private List<UpgradePlayerHealthViewData> _healthViewData;
    [SerializeField] private List<UpgradePlayerDamageViewData> _damageViewData;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private UpgradeView _upgradePrefab;
    [SerializeField] private ShoppingCart _shoppingCart;

    private void Start()
    {
        foreach (var data in _healthViewData)
        {
            AddHealthUpgrade(data);
        }

        foreach (var data in _damageViewData)
        {
            AddDamageUpgrade(data);
        }
    }

    private void AddHealthUpgrade(UpgradePlayerHealthViewData data)
    {
        var upgrade = Instantiate(_upgradePrefab, _itemContainer.transform);
        upgrade.Init(data, new SaveUpgrade<Health, int>(new BinaryStorage(), data.HealthCount, $"{data.Price} {data.name} {data.HealthCount} {data.Description} {data.FullDescription}"), _shoppingCart);
    }
    
    private void AddDamageUpgrade(UpgradePlayerDamageViewData data)
    {
        var upgrade = Instantiate(_upgradePrefab, _itemContainer.transform);
        upgrade.Init(data, new SaveUpgrade<PlayerCollision, int>(new BinaryStorage(), data.Damage, $"{data.Price} {data.Damage} {data.name} {data.Description} {data.FullDescription}"), _shoppingCart);
    }
}