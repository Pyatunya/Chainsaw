using System;
using UnityEngine;

public sealed class UpgradeSelector : MonoBehaviour
{
    [SerializeField] private UpgradePanel _panel;
    private UpgradeView _upgrade;
    
    public void Select(UpgradeView upgradeView)
    {
        if (upgradeView == null)
            throw new ArgumentNullException(nameof(upgradeView));
        
        var fullDescription = upgradeView.Data.FullDescription;
        _panel.Show(fullDescription, upgradeView.Data.Icon);

        if (upgradeView.CanSelect)
        {
            upgradeView.Select();
        }

        else if (upgradeView.Upgrade.HasUsed == false)
        {
            upgradeView.Unselect();
        }
    }
}