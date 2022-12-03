using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class ExplosionZombie : MonoBehaviour
{
    [SerializeField] private float _explosionTime = 5;
    [SerializeField] private float _explosionTimeOnDamage = 2;
    [SerializeField] private float _explosionRadius = 3;

    [SerializeField] private Health _health;
    [SerializeField] private ZombieCollision _zombieCollision;

    private float _elapsedTimeExplosion = 0;
    private bool _hasExploded = false;
    private bool _isDamageReceived = false;

    private void Update()
    {
        _elapsedTimeExplosion += Time.deltaTime;

        if (_elapsedTimeExplosion >= _explosionTime && _hasExploded == false && _isDamageReceived == false)
        {
            print("обнуление");
            _hasExploded = true;
            SelfDestructs();
        }

        if (_isDamageReceived && _elapsedTimeExplosion >= _explosionTimeOnDamage && _hasExploded == false)
        {
            print("получает урон");
            _hasExploded = true;
            SelfDestructs();
        }
    }

    private void OnEnable()
    {
        _health.OnDied += OnDie;
        _health.OnDamaged += OnDamaged;
    }

    private void OnDisable()
    {
        _health.OnDied -= OnDie;
        _health.OnDamaged -= OnDamaged;
    }

    private void OnDie()
    {
        print("Умер");

        Attack();
    }

    private void Attack()
    {
        Collider2D[] explosionRadius = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

        for (int i = 0; i < explosionRadius.Length; i++)
        {
            if (explosionRadius[i].TryGetComponent(out Health health))
            {
                print("все получают урон");
                health.TakeDamage(_zombieCollision.Damage);
            }
        }
    }

    private void OnDamaged()
    {
        _isDamageReceived = true;
        _elapsedTimeExplosion = 0;
    }

    private void SelfDestructs()
    {
        print("Получаю урон от себя");
        _health.TakeDamage(_zombieCollision.Damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
