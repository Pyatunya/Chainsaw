using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Button))]
public abstract class Button : MonoBehaviour
{
    private UnityEngine.UI.Button _button;

    private void Start()
    {
        _button = GetComponent<UnityEngine.UI.Button>();
        _button.onClick.AddListener(OnClick);
    }
    
    private void OnDestroy() => _button.onClick.RemoveListener(OnClick);

    protected abstract void OnClick();
}