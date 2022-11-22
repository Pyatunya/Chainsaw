public interface IShoppingCart
{
    int Price { get; }
    
    void Add(IUpgradeView view);
    
    void Remove(IUpgradeView view);
}