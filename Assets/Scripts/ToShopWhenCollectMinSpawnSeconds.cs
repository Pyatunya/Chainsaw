using System.Collections;
using System.Linq;
using Shooter.LoadSystem;
using UnityEngine;

public sealed class ToShopWhenCollectMinSpawnSeconds : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Animator _clearAllInCanvas;
    [SerializeField] private Animator _displayNewCanvas;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private SceneData _shop;
    private bool _wasAnimationPlayed;

    private void Update()
    {
        if(_wasAnimationPlayed)
            return;
        
        if (_enemySpawner.IsMinSpawnSeconds && FindObjectsOfType<Zombie>().Length == 0)
        {
            Debug.Log("GameOver");

            StartCoroutine(GoToShop());
        }
    }

    private IEnumerator GoToShop()
    {
        _wasAnimationPlayed = true;
        _clearAllInCanvas.SetBool("ToShop", true);
        yield return new WaitForSeconds(2.3f);
        _clearAllInCanvas.SetBool("ToShop", false);
        _displayNewCanvas.SetBool("DisplayNewCanvas", true);
        yield return new WaitForSeconds(4.5f);
        _displayNewCanvas.SetBool("DisplayNewCanvas", false);
        _sceneLoader.Load(_shop);
    }
}