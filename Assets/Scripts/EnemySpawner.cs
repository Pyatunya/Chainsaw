using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class EnemySpawner : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _startSpawnSeconds = 1f;
    [SerializeField, Min(0.1f)] private float _targetSpawnSeconds = 0.45f;
    [SerializeField] private Entity[] _prefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Score _score;

    public bool IsMinSpawnSeconds => _startSpawnSeconds <= _targetSpawnSeconds;
    
    private readonly Dictionary<Entity, IndependentPool<Entity>> _pools = new();
    private Coroutine _changeSpawnRateRoutine;
    private Coroutine _spawnRoutine;

    private void Start()
    {
        foreach (var prefab in _prefabs)
        {
            _pools.Add(prefab, new IndependentPool<Entity>(new GameObjectsFactory<Entity>(prefab)));
        }

        _changeSpawnRateRoutine = StartCoroutine(ChangeSpawnRate());
        _spawnRoutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_startSpawnSeconds);
            var prefab = _prefabs[Random.Range(0, _prefabs.Length)];
            var entity = _pools[prefab].Get();

            entity.Init(_score);
            entity.gameObject.SetActive(true);
            entity.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        }
    }

    private IEnumerator ChangeSpawnRate()
    {
        const float spawnTimeChangeValue = 0.1f;
        var timeBetweenChanges = new WaitForSeconds(4f);

        while (_startSpawnSeconds >= _targetSpawnSeconds)
        {
            if (_startSpawnSeconds == 0.3f)
                yield return new WaitForSeconds(60);
            
            yield return timeBetweenChanges;
            _startSpawnSeconds -= spawnTimeChangeValue;
        }
    }

    public void OnLevelEnded()
    {
        StopCoroutine(_changeSpawnRateRoutine);
        StopCoroutine(_spawnRoutine);
    }
}