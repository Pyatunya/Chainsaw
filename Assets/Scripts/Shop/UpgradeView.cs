using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class UpgradeView : MonoBehaviour, IUpgradeView
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _tittle;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _checkMark;
    [SerializeField] private Image _hasUsedImage;
    private IShoppingCart _shoppingCart;

    public bool CanSelect { get; private set; } = true;
    
    public UpgradeViewData Data { get; private set; }

    public IUpgrade Upgrade { get; private set; }

    public void Init(UpgradeViewData data, IUpgrade upgrade, IShoppingCart shoppingCart)
    {
        Data = data ?? throw new ArgumentNullException(nameof(data));
        Upgrade = upgrade ?? throw new ArgumentNullException(nameof(upgrade));
        _shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
        
        _description.text = data.Description;
        _tittle.text = data.Title;
        _price.text = data.Price.ToString();
        _image.sprite = data.Icon;

        if (Upgrade.HasUsed)
        {
            Use();
        }
    }

    public void Use()
    {
        CanSelect = false;
        _hasUsedImage.gameObject.SetActive(true);
    }

    public void Select()
    {
        if (!CanSelect)
            throw new InvalidOperationException("Already selected!");

        _shoppingCart.Add(this);
        CanSelect = false;
        _checkMark.gameObject.SetActive(true);
    }

    public void Unselect()
    {
        if (CanSelect)
            throw new InvalidOperationException("Already unselected!");

        _shoppingCart.Remove(this);
        CanSelect = true;
        _checkMark.gameObject.SetActive(false);
    }
}