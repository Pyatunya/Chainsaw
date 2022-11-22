using UnityEngine;

public sealed class UpgradeSelector : MonoBehaviour
{
    [SerializeField] private UpgradePanel _panel;
    private Camera _camera;
    private UpgradeView _upgrade;

    private void Start() => _camera = Camera.main;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(mousePosition, Vector2.up);
            
            if (hit.transform != null)
            {
                if (hit.transform.TryGetComponent(out UpgradeView upgrade))
                {
                    var fullDescription = upgrade.Data.FullDescription;
                    Select(upgrade);
                    _panel.Show(fullDescription, upgrade.Data.Icon);
                }
            }
        }
    }

    private void Select(UpgradeView upgradeView)
    {
        if (upgradeView.CanSelect)
        {
            upgradeView.Select();
        }
        
        else if(upgradeView.Upgrade.HasUsed == false)
        {
            upgradeView.Unselect();
        }
    }
}