using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public sealed class LoadingInterest : MonoBehaviour
{
    private static TextMeshProUGUI _text;

    private void Start() => _text = GetComponent<TextMeshProUGUI>();

    public static void Visualize(float interest)
    {
        var value = Mathf.Lerp(0, 100, interest);
        var valueText = value.ToString();

        if (valueText.Length > 2)
            valueText = $"{valueText[0]}{valueText[1]}";
        _text.text = $"{valueText} %";
    }
}