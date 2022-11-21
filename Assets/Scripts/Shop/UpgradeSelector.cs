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
            
            var hit = Physics2D.Raycast(Vector2.zero, mousePosition - transform.position);
            Debug.Log($"try hit {hit.point}");
            if (hit.transform != null)
            {
                Debug.Log(hit.transform.name);
                
                if (hit.transform.TryGetComponent(out UpgradeView upgrade))
                {
                    Debug.Log("hit");

                    var fullDescription = upgrade.ViewData.FullDescription;
                    Select(upgrade);
                    _panel.Show(fullDescription, upgrade.ViewData.Icon);
                }
            }
        }
    }

    private void Select(UpgradeView upgrade)
    {
        if (upgrade.IsSelected)
        {
            upgrade.Select();
        }
        else
        {
            upgrade.Unselect();
        }
    }
}