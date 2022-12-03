using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class ZombieSpawner : EnemySpawner
{
    [SerializeField] private Transform[] _spawnPoints;
    // [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private Score _score;
    [SerializeField] private ComboCounter _comboCounter;
    [SerializeField] private Player _player;

    private readonly Dictionary<Zombie, IndependentPool<Zombie>> _pools = new();
    
    public Zombie[] Prefabs { get; private set; }

    public void SwitchPrefabs(Zombie[] prefabs)
    {
        Prefabs = prefabs ?? throw new ArgumentNullException(nameof(prefabs));
        
        foreach (var prefab in prefabs)
        {
            if (_pools.ContainsKey(prefab) == false)
                _pools.Add(prefab, new IndependentPool<Zombie>(new GameObjectsFactory<Zombie>(prefab, transform)));
        }
    }

    public override IEntity Create()
    {
        var prefab = Prefabs[Random.Range(0, Prefabs.Length)];
        var zombie = _pools[prefab].Get();
        zombie.Init(_player);

        zombie.Init(_score, _comboCounter);
        zombie.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        zombie.gameObject.SetActive(true);
        return zombie;
    }
}