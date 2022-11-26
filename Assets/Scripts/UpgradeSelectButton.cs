using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UpgradeView))]
[RequireComponent(typeof(Button))]
public sealed class UpgradeSelectButton : MonoBehaviour
{
    private Button _button;
    private UpgradeView _upgradeView;
    private UpgradeSelector _upgradeSelector;
    
    private void OnEnable()
    {
        _upgradeSelector = FindObjectOfType<UpgradeSelector>();
        _upgradeView = GetComponent<UpgradeView>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }
    
    private void OnDestroy() => _button.onClick.RemoveListener(OnClick);

    private void OnClick()
    {
        _upgradeSelector.TrySelect(_upgradeView);
    }
}