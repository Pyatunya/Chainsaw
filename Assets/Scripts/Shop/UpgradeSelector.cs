using UnityEngine;

public sealed class UpgradeSelector : MonoBehaviour
{
    [SerializeField] private UpgradePanel _panel;
    private Camera _camera;
    private UpgradeView _upgrade;

    private void Start() => _camera = Camera.main;

    public void TrySelect(UpgradeView upgradeView)
    {
        var fullDescription = upgradeView.Data.FullDescription;
        Select(upgradeView);
        _panel.Show(fullDescription, upgradeView.Data.Icon);
    }

    private void Select(UpgradeView upgradeView)
    {
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