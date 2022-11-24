using System.Collections;
using Shooter.LoadSystem;
using UnityEngine;

public sealed class ToShopWhenCollectMinSpawnSeconds : MonoBehaviour
{
    [SerializeField] private Animator _clearAllInCanvas;
    [SerializeField] private Animator _displayNewCanvas;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private SceneData _shop;
    [SerializeField] private LevelTimer _levelTimer;

    private void OnEnable()
    {
        _levelTimer.LevelCompleted += OnLevelCompleted;
    }

    private void OnDisable()
    {
        _levelTimer.LevelCompleted -= OnLevelCompleted;
    }

    private void OnLevelCompleted() => StartCoroutine(GoToShop());

    private IEnumerator GoToShop()
    {
        while (FindObjectsOfType<Zombie>().Length > 0)
        {
            yield return null;
        }
        
        _clearAllInCanvas.SetBool("ToShop", true);
        yield return new WaitForSeconds(2.3f);
        _clearAllInCanvas.SetBool("ToShop", false);
        _displayNewCanvas.SetBool("DisplayNewCanvas", true);
        yield return new WaitForSeconds(4.5f);
        _displayNewCanvas.SetBool("DisplayNewCanvas", false);
        _sceneLoader.Load(_shop);
    }
}