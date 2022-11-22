public interface IUpgradeView
{
    UpgradeViewData Data { get; }
    
    IUpgrade Upgrade { get; }
    
    bool CanSelect { get; }
}