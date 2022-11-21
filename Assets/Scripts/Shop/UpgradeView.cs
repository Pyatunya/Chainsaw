using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class UpgradeView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _tittle;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _checkMark;
    private ShoppingCart _shoppingCart;
    
    public UpgradeViewData ViewData { get; private set; }

    public IUpgrade Upgrade { get; private set; }
    
    public bool IsSelected { get; private set; }
    
    public void Init(UpgradeViewData viewData, IUpgrade upgrade, ShoppingCart shoppingCart)
    {
        ViewData = viewData ?? throw new ArgumentNullException(nameof(viewData));
        _description.text = viewData.Description;
        _tittle.text = viewData.Title;
        _price.text = viewData.Price.ToString();
        _image.sprite = viewData.Icon;
        Upgrade = upgrade ?? throw new ArgumentNullException(nameof(upgrade));
        _shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
    }

    public void Select()
    {
        if (IsSelected)
            throw new InvalidOperationException("Already selected!");
        
        _shoppingCart.Add(ViewData);
        SetIsSelected(true);
    }

    public void Unselect()
    {
        if (!IsSelected)
            throw new InvalidOperationException("Already selected!");
        
        _shoppingCart.Remove(ViewData);
        SetIsSelected(false);
    }

    private void SetIsSelected(bool isSelected)
    {
        IsSelected = isSelected;
        _checkMark.gameObject.SetActive(isSelected);
    }
}