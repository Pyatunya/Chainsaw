using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Udgrade data", menuName = "Create/Upgrate")]
public class UpgradeViewData : ScriptableObject
{
    [field : SerializeField] public string Discription { get; private set; } 
    [field : SerializeField] public string Title { get; private set; } 
    [field : SerializeField] public int Price { get; private set; } 
    [field : SerializeField] public Sprite Icon { get; private set; } 
}
