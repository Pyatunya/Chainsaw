using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade data", menuName = "Create/Player Damage Upgrade")]
public sealed class UpgradePlayerDamageViewData : UpgradeViewData
{
    [field: SerializeField, Min(1)] public int Damage { get; private set; }
}