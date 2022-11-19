using TMPro;
using UnityEngine;

public sealed class CountView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Visualize(int count)
    {
        _text.text = count.ToString();
    }
}