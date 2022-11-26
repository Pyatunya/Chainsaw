using System.Collections;
using UnityEngine;

public sealed class DamageBlink : MonoBehaviour
{
    [SerializeField] private float _blinkSeconds = 1.5f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    private Coroutine _onDamaging;
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
        _health.OnDamaged += OnDamaged;
    }

    private void OnDestroy() => _health.OnDamaged -= OnDamaged;

    private void OnDamaged()
    {
        if (_onDamaging == null)
            _onDamaging = StartCoroutine(OnDamaging());
    }

    private IEnumerator OnDamaging()
    {
        var color = _spriteRenderer.color;
        var elapsed = 0f;
        _spriteRenderer.color = Color.white;

        while (elapsed < _blinkSeconds)
        {
            elapsed += Time.deltaTime;
            _spriteRenderer.color = Color.Lerp(Color.white, color, elapsed / _blinkSeconds);
            yield return null;
        }

        _onDamaging = null;
    }
}