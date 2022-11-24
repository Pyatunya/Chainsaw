using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class UpgradePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _icon;
    
    public void Show(string description, Sprite icon)
    {
        gameObject.SetActive(true);
        _text.text = description;
        _icon.sprite = icon ?? throw new ArgumentNullException(nameof(icon));
    }
}