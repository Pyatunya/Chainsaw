using System.Collections;
using UnityEngine;

public class ExplosionZombie : MonoBehaviour
{
    [SerializeField] private float _explosionTime = 5;
    [SerializeField] private float _explosionTimeOnDamage = 2;
    [SerializeField] private float _explosionRadius = 3;

    [SerializeField] private Health _health;
    [SerializeField] private ZombieCollision _zombieCollision;

    private bool _hasExploded;
    private Coroutine _startSelfDestructsRoutine;

    private void OnEnable()
    {
        _health.OnDied += OnDie;
        _health.OnDamaged += OnDamaged;
        _hasExploded = false;
        _startSelfDestructsRoutine = StartCoroutine(StartSelfDestructs(_explosionTime));
    }

    private void OnDisable()
    {
        _health.OnDied -= OnDie;
        _health.OnDamaged -= OnDamaged;
    }

    private IEnumerator StartSelfDestructs(float time)
    {
        yield return new WaitForSeconds(time);
        SelfDestructs();
    }

    private void OnDie()
    {
        if (_hasExploded == false)
        {
            _hasExploded = true;
            Explode();
        }
    }

    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider != GetComponent<BoxCollider2D>())
            {
                if (collider.TryGetComponent(out Health health))
                {
                    health.TakeDamage(_zombieCollision.Damage);
                }
            }
        }
    }

    private void OnDamaged()
    {
        if (_startSelfDestructsRoutine != null)
            StopCoroutine(_startSelfDestructsRoutine);

        _startSelfDestructsRoutine = StartCoroutine(StartSelfDestructs(_explosionTimeOnDamage));
    }

    private void SelfDestructs()
    {
        _health.TakeDamage(_zombieCollision.Damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}