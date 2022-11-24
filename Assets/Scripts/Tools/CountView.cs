using System.Linq;
using TMPro;
using UnityEngine;

public sealed class CountView : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _texts;

    public void Visualize(int count)
    {
        _texts.ToList().ForEach(text => text.text = count.ToString());
    }
}