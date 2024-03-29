﻿using UnityEngine;

[RequireComponent(typeof(Button), typeof(UpgradeView))]
public sealed class UpgradeSelectButton : MonoBehaviour
{
    private UnityEngine.UI.Button _button;
    private UpgradeView _upgradeView;
    private UpgradeSelector _upgradeSelector;
    
    public void OnEnable()
    {
        _upgradeSelector = FindObjectOfType<UpgradeSelector>();
        _upgradeView = GetComponent<UpgradeView>();
        _button = GetComponent<UnityEngine.UI.Button>();
        _button.onClick.AddListener(OnClick);
    }
    
    private void OnDestroy() => _button.onClick.RemoveListener(OnClick);

    private void OnClick()
    {
        _upgradeSelector.Select(_upgradeView);
    }
}