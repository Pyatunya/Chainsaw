using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public sealed class ExitButton : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Exit);
    }

    private void OnDestroy() => _button.onClick.RemoveListener(Exit);

    private void Exit()
    {
        Application.Quit();
    }
}
