using UnityEngine;

public sealed class ZombieLoot : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int _chance;
    [SerializeField] GameObject _loot;
    // [SerializeField] private ParticleSystem _vfx;

    private const int MaxValue = 100;

    private void OnEnable()
    {
        _health.OnDied += OnDied;
    }

    private void OnDisable()
    {
        _health.OnDied -= OnDied;
    }

    private void OnDied()
    {
        DropLoot();
    }

    private void DropLoot()
    {
        int randomChance = Random.Range(0, MaxValue);
        var position = transform.position;
        // Instantiate(_vfx, position, Quaternion.identity).Play();

        if (randomChance > _chance)
        {
            Instantiate(_loot, position, Quaternion.identity);
        }
    }
}