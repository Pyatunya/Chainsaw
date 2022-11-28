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
    private readonly int _displayNewCanvasId = Animator.StringToHash("DisplayNewCanvas");
    private readonly int _toShopId = Animator.StringToHash("ToShop");
    
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
        
        _clearAllInCanvas.SetBool(_toShopId, true);
        yield return new WaitForSeconds(2.3f);
        _clearAllInCanvas.SetBool(_toShopId, false);
        _displayNewCanvas.SetBool(_displayNewCanvasId, true);
        yield return new WaitForSeconds(4.5f);
        _displayNewCanvas.SetBool(_displayNewCanvasId, false);
        _sceneLoader.Load(_shop);
    }
}