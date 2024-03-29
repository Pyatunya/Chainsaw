﻿using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public sealed class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _texts;

    private readonly List<(int, string)> _digitsPrefixes = new()
    {
        (1000, "K"),
        (1000000, "M"),
        (1000000000, "B")
    };

    public void Visualize(int count)
    {
        var text = count.ToString();
        
        if (count > 1000)
        {
            for (var i = 0; i < _digitsPrefixes.Count - 1; ++i)
            {
                var (currentValue, currentPostfix) = _digitsPrefixes[i];
                var (nextValue, nextPostfix) = _digitsPrefixes[i + 1];
                var nextIsLast = i >= _digitsPrefixes.Count - 2;

                if (nextValue > count)
                {
                    float result = (float)count / currentValue;
                    text = result.ToString(result >= 100 ? "0" : "0.0").Replace(".0", "") + currentPostfix;
                    break;
                }

                if (nextIsLast)
                {
                    float result = (float)count / nextValue;
                    text = result.ToString(result >= 100 ? "0" : "0.0").Replace(".0", "") + nextPostfix;
                }
            }
        }

        _texts.ToList().ForEach(text => text.text = count.ToString());
        _texts[0].text = text;
    }
}