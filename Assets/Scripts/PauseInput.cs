using UnityEngine;

public sealed class PauseInput : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameLoop _gameLoop;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _panel.SetActive(true);
            _gameLoop.Pause();
        }
    }
}
