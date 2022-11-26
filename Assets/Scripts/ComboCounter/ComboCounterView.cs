using TMPro;
using UnityEngine;

public sealed class ComboCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Animation _textShake;
    
    public void Visualize(int count)
    {
        _text.text = count.ToString();

        if (count % 10 == 0)
        {
            _textShake.Play();
        }
        
        else if(_textShake.IsPlaying(_textShake.name))
        {
            _textShake.Stop(_textShake.name);
        }
        
        if (count == 0)
            _text.text = string.Empty;
    }
}