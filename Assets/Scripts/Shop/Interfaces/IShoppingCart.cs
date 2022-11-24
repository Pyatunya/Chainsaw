using System.Collections.Generic;

public interface IShoppingCart
{
    public IEnumerable<IUpgradeView> Views { get; }
    
    int Price { get; }
    
    void Add(IUpgradeView view);
    
    void Remove(IUpgradeView view);
}