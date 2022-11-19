using System;
using UnityEngine;

public sealed class Wallet : MonoBehaviour
{
    [SerializeField] private WalletView _view;
    private readonly StorageWithNameSaveObject<Wallet, int> _storage = new();
    private int _money;

    private void OnEnable()
    {
        _money = _storage.HasSave() ? _storage.Load() : 0;
        _view.Visualize(_money);
    }

    public void Put(int money)
    {
        if (money <= 0)
            throw new ArgumentOutOfRangeException(nameof(money));

        _money += money;
        VisualizedAndSave(_money);
    }

    private void VisualizedAndSave(int money)
    {
        _view.Visualize(money);
        _storage.Save(money);
    }

    public void Take(int money)
    {
        if (money <= 0)
            throw new ArgumentOutOfRangeException(nameof(money));

        if (CanTake(money) == false)
            throw new InvalidOperationException($"Can't take {money} ");

        _money -= money;
        VisualizedAndSave(_money);
    }

    private bool CanTake(int money) => _money - money >= 0;
}