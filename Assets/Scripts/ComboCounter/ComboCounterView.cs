using TMPro;
using UnityEngine;

public sealed class ComboCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    public void Visualize(int count)
    {
        _text.text = count.ToString();

        if (count == 0)
            _text.text = string.Empty;
    }
}