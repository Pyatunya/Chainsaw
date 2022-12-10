using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class ZombieSpawner : EnemySpawner
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Score _score;
    [SerializeField] private ComboCounter _comboCounter;
    [SerializeField] private Player _player;
    [SerializeField] private Zombie[] _prefabs;

    private readonly Dictionary<Zombie, IndependentPool<Zombie>> _pools = new();
    
    public void Start()
    {
        foreach (var prefab in _prefabs)
        {
            _pools.Add(prefab, new IndependentPool<Zombie>(new GameObjectsFactory<Zombie>(prefab, transform)));
        }
    }

    public override IEntity Create()
    {
        var prefab = _prefabs[Random.Range(0, _prefabs.Length)];
        var zombie = _pools[prefab].Get();
        zombie.Init(_player);

        zombie.Init(_score, _comboCounter);
        zombie.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        zombie.gameObject.SetActive(true);
        return zombie;
    }
}