﻿using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade data", menuName = "Create/Health Upgrade")]
public sealed class UpgradeHealthViewData : UpgradeViewData
{
    [field: SerializeField, Min(10)] public int HealthCount { get; private set; }
}