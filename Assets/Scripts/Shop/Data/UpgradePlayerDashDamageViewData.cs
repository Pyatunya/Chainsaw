using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade dash", menuName = "Create/Player Dash Damage Upgrade")]
public sealed class UpgradePlayerDashDamageViewData : UpgradeViewData
{
    [field: SerializeField, Min(1)] public int Damage { get; private set; }
}