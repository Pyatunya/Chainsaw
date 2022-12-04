using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class ZombieDieAnimation : MonoBehaviour
{
    [SerializeField] private ZombieAnimation _zombieAnimation;
    [SerializeField] private Health _health;
    [SerializeField] private string[] _dieAnimationsBoolNames;
    [SerializeField] private GameObject _zombieDiePrefab;
    [SerializeField] private ZombieCollision _zombieCollision;
    private Rigidbody2D _rigidbody;
    private Coroutine _onDying;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _zombieCollision = GetComponent<ZombieCollision>();
    }

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
        
        Destroy(_zombieCollision);
        _rigidbody.bodyType = RigidbodyType2D.Static;
        
        for (var i = 0; i < colliders.Length; i++)
        {
            Destroy(colliders[i]);
        }
        
        yield return new WaitForSeconds(_zombieAnimation.Animator.GetCurrentAnimatorClipInfo(0).Length);
        Instantiate(_zombieDiePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}