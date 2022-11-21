using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesShop : MonoBehaviour
{
    [SerializeField] private List<UpgradeViewData> _upgrades;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private Upgrade _upgradePrefab;

    private void Start()
    {
        for (int i = 0; i < _upgrades.Count; i++)
        {
            AddItem(_upgrades[i]);
        }
    }

    private void AddItem(UpgradeViewData upgrade)
    {
        var view = Instantiate(_upgradePrefab, _itemContainer.transform);

        view.Init(upgrade);
    }
}
