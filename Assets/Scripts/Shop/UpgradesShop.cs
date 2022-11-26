using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class UpgradesShop : MonoBehaviour
{
    [SerializeField] private UINavigation _uiNavigation;
    [SerializeField] private List<UpgradePlayerHealthViewData> _healthViewData;
    [SerializeField] private List<UpgradePlayerDamageViewData> _damageViewData;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private UpgradeView _upgradePrefab;
    [SerializeField] private ShoppingCart _shoppingCart;

    private void Start()
    {
        AddHealthUpgrade();
        AddDamageUpgrades();
    }

    private void AddHealthUpgrade()
    {
        AddSaveUpgrades<Health, int, UpgradePlayerHealthViewData>(data => data.HealthCount, _healthViewData);
    }

    private void AddDamageUpgrades()
    {
        AddSaveUpgrades<PlayerCollision, int, UpgradePlayerDamageViewData>(data => data.Damage, _damageViewData);
    }

    private void AddSaveUpgrades<TStorageType, TSaveType, TData>(Func<TData, TSaveType> saveTypeProvider, IReadOnlyList<TData> dataList) where TData : UpgradeViewData
    {
        var upgradeViews = CreateViews(dataList.Count);
        for (var i = 0; i < dataList.Count; i++)
        {
            var worseUpgradesSwitch = new WorseUpgradesSwitch(upgradeViews.GetRange(0, i));
            var data = dataList[i];
            var path = $"{data.Price} {data.name} {data.Title} {data.Icon.name} g {data.Description} {data.FullDescription}";
            var upgradeView = upgradeViews[i];
            upgradeView.Init(data, new SaveUpgrade<TStorageType, TSaveType>(new BinaryStorage(), saveTypeProvider.Invoke(data), worseUpgradesSwitch, path), _shoppingCart);
        }
    }

    private List<UpgradeView> CreateViews(int count)
    {
        var list = new List<UpgradeView>();
        
        for (var i = 0; i < count; i++)
        {
            var upgradeView = Instantiate(_upgradePrefab, _itemContainer.transform);
            list.Add(upgradeView);
            _uiNavigation.Add(upgradeView.GetComponent<Image>());
        }

        return list;
    }
}