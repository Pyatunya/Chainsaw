using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Button))]
public sealed class UpgradeButton : Button
{
    [SerializeField] private ShoppingCart _shoppingCart;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _notEnoughMoney;
    
    protected override void OnClick() => Upgrade();
    
    private void Upgrade()
    {
        var price = _shoppingCart.Price;

        if (_wallet.CanTake(price))
        {
            _wallet.Take(price);
            
            foreach (var upgradeView in _shoppingCart.Views)
            {
                upgradeView.Use();
                upgradeView.Upgrade.Use();
            }

            _shoppingCart.Clear();
        }
        
        else
        {
            StartCoroutine(ShowNotEnoughMoney(price));
        }
    }

    private IEnumerator ShowNotEnoughMoney(int price)
    {
        _notEnoughMoney.text = $"You need {_wallet.Money - price} blood more!";
        yield return new WaitForSeconds(0.8f);
        _notEnoughMoney.text = string.Empty;
    }
}