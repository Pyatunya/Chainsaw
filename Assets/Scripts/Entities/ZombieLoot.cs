using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLoot : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private int _chance;
    [SerializeField] GameObject _loot;

    private int _maxValue = 100;

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
        int randomChance = Random.Range(0, _maxValue);

        if (randomChance > _chance)
            Instantiate(_loot, transform.position, Quaternion.identity);
    }
}
