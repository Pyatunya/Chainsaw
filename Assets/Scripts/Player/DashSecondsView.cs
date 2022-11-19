using System;
using TMPro;
using UnityEngine;

public sealed class DashSecondsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    public void Visualize(float seconds)
    {
        if (seconds > 3)
            seconds = 3;

        var secondsText = MathF.Truncate(seconds).ToString();
        _text.text = secondsText;
    }
}