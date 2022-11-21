using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public UpgradeViewData UpgradeViewData { get; private set; }

    public void Init(UpgradeViewData upgradeViewData)
    {
        UpgradeViewData = upgradeViewData;
    }
}
