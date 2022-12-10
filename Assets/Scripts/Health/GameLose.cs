using UnityEngine;

public sealed class GameLose : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private GameLoop _gameLoop;

    [field: SerializeField] public Health Health { get; private set; }

    private void OnEnable() => Health.OnDied += EndGame;

    private void OnDisable() => Health.OnDied -= EndGame;

    private void EndGame()
    {
        if (_endGamePanel != null)
            _endGamePanel.gameObject.SetActive(true);
        
        _gameLoop.Pause();
    }
}