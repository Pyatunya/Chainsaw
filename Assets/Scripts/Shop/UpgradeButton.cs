using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public sealed class UpgradeButton : MonoBehaviour
{
    [SerializeField] private ShoppingCart _shoppingCart;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _notEnoughMoney;
    
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Upgrade);
    }

    private void OnDestroy() => _button.onClick.RemoveListener(Upgrade);

    private void Upgrade()
    {
        var price = _shoppingCart.Price;

        if (_wallet.CanTake(price))
        {
            _wallet.Take(price);
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