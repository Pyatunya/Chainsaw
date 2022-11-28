using UnityEngine;

public sealed class ZombieLoot : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int _chance;
    [SerializeField] private GameObject _loot;

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

        if (randomChance > _chance)
        {
            Instantiate(_loot, position, Quaternion.identity);
        }
    }
}