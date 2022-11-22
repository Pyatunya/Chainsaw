using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class EnemySpawner : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _spawnSeconds = 0.45f;
    [SerializeField] private Entity[] _prefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Score _score;
    
    private Dictionary<Entity, IndependentPool<Entity>> _pools = new();

    private IEnumerator Start()
    {
        foreach (var prefab in _prefabs)
        {
            _pools.Add(prefab, new IndependentPool<Entity>(new GameObjectsFactory<Entity>(prefab)));
        }

        while (true)
        {
            yield return new WaitForSeconds(_spawnSeconds);
            var prefab = _prefabs[Random.Range(0, _prefabs.Length)];
            var entity = _pools[prefab].Get();

            entity.Init(_score);
            entity.gameObject.SetActive(true);
            entity.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        }
    }
}