using System;
using System.Collections.Generic;
using System.Linq;
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
        AddHealthUpgrade();
        AddDamageUpgrade();
    }

    private void AddHealthUpgrade()
    {
        AddSaveUpgrades<Health, int, UpgradePlayerHealthViewData>(data => data.HealthCount, _healthViewData);
    }

    private void AddDamageUpgrade()
    {
        AddSaveUpgrades<PlayerCollision, int, UpgradePlayerDamageViewData>(data => data.Damage, _damageViewData);
    }

    private void AddSaveUpgrades<TStorageType, TSaveType, TData>(Func<TData, TSaveType> saveTypeProvider, IReadOnlyList<TData> dataList) where TData : UpgradeViewData
    {
        var upgradeViews = CreateViews(dataList.Count);
        for (var i = 0; i < dataList.Count; i++)
        {
            var worseUpgradesSwitch = new WorseUpgradesSwitch(upgradeViews.ToList().GetRange(0, i));
            var data = dataList[i];
            var path = $"{data.Price} {data.name} {data.Title} {data.Icon.name} {data.Description} {data.FullDescription}";
            var upgradeView = upgradeViews.ElementAt(i);
            upgradeView.Init(data, new SaveUpgrade<TStorageType, TSaveType>(new BinaryStorage(), saveTypeProvider.Invoke(data), worseUpgradesSwitch, path), _shoppingCart);
        }
    }

    private IEnumerable<UpgradeView> CreateViews(int count)
    {
        Debug.Log(count);
        for (var i = 0; i < count; i++)
        {
            yield return Instantiate(_upgradePrefab, _itemContainer.transform);
        }
    }
}