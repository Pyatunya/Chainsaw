using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private Collider2D[] _colliders;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _colliders = GetComponents<Collider2D>();
        
        if (_colliders.Length == 0)
            throw new System.InvalidOperationException("Zombie doesn't have colliders!");
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
        Destroy(_zombieCollision);
        _rigidbody.bodyType = RigidbodyType2D.Static;
        
        for (var i = 0; i < _colliders.Length; i++)
        {
            Destroy(_colliders[i]);
        }
        
        yield return new WaitForSeconds(_zombieAnimation.Animator.GetCurrentAnimatorClipInfo(0).Length);
        Instantiate(_zombieDiePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}