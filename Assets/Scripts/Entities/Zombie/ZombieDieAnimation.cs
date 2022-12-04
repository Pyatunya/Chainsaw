using System.Collections;
using System.Linq;
using UnityEngine;

public sealed class ZombieDieAnimation : MonoBehaviour
{
    [SerializeField] private ZombieAnimation _zombieAnimation;
    [SerializeField] private Health _health;
    [SerializeField] private string[] _dieAnimationsBoolNames;
    [SerializeField] private Sprite _dieSprite;
    [SerializeField] private Rigidbody2D _rigidbody;
    private Coroutine _onDying;
    
    private void OnEnable() => _health.OnDied += OnDied;

    private void OnDisable() => _health.OnDied -= OnDied;

    private void OnDied()
    {
        if (_onDying == null)
            _onDying = StartCoroutine(OnDying());
    }

    private IEnumerator OnDying()
    {
        var dieAnimationsTriggerName = _dieAnimationsBoolNames[Random.Range(0, _dieAnimationsBoolNames.Length)];
        _zombieAnimation.StopAll();
        _zombieAnimation.Animator.SetTrigger(dieAnimationsTriggerName);
        var colliders = GetComponents<Collider2D>();
        
        Destroy(GetComponent<ZombieCollision>());
        Destroy(GetComponent<Zombie>());
        Destroy(GetComponent<Rigidbody2D>());
        
        for (var i = 0; i < colliders.Length; i++)
        {
            Destroy(colliders[i]);
        }
        
        yield return new WaitForSeconds(_zombieAnimation.Animator.GetCurrentAnimatorClipInfo(0).Length);
        _zombieAnimation.SpriteRenderer.sprite = _dieSprite;
    }
}