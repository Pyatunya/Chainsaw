using UnityEngine;

[CreateAssetMenu(fileName = "Udgrade data", menuName = "Create/Upgrade")]
public class UpgradeViewData : ScriptableObject
{
    [field: SerializeField] public string Description { get; private set; }
    
    [field: SerializeField] public string FullDescription { get; private set; }

    
    [field: SerializeField] public string Title { get; private set; }
    
    [field: SerializeField] public int Price { get; private set; }
    
    [field: SerializeField] public Sprite Icon { get; private set; }
}