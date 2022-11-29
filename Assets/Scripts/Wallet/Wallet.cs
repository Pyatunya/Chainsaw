using System;
using UnityEngine;

public sealed class Wallet : MonoBehaviour
{
    [SerializeField] private WalletView _view;
    private readonly StorageWithNameSaveObject<Wallet, int> _storage = new();
    
    public int Money { get; private set; }

    private void OnEnable()
    {
        Money = _storage.HasSave() ? _storage.Load() : 0;
        _view.Visualize(Money);
    }

    public void Put(int money)
    {
        if (money <= 0)
            throw new ArgumentOutOfRangeException(nameof(money));

        Money += money;
        VisualizedAndSave(Money);
    }

    private void VisualizedAndSave(int money)
    {
        _view.Visualize(money);
        _storage.Save(money);
    }

    public void Take(int money)
    {
        if (money < 0)
            throw new ArgumentOutOfRangeException(nameof(money));

        if (CanTake(money) == false)
            throw new InvalidOperationException($"Can't take {money} ");

        Money -= money;
        VisualizedAndSave(Money);
    }

    public bool CanTake(int money) => Money - money >= 0;
    
}