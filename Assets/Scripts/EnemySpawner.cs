using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Entity[] _prefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Score _score;
    [SerializeField] private LevelTimer _levelTimer;

    private float _startSpawnSeconds = 0.3f;
    private float _difficultSpawnSeconds = 0.15f;
    private readonly Dictionary<Entity, IndependentPool<Entity>> _pools = new();
    private Coroutine _changeSpawnRateRoutine;
    private Coroutine _spawnRoutine;

    private void Start()
    {
        _levelTimer.LevelCompleted += OnLevelCompleted;
        _levelTimer.LevelDifficultIncreased += OnLevelDifficultIncreased;

        foreach (var prefab in _prefabs)
        {
            _pools.Add(prefab, new IndependentPool<Entity>(new GameObjectsFactory<Entity>(prefab)));
        }

        _spawnRoutine = StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        _levelTimer.LevelCompleted -= OnLevelCompleted;
        _levelTimer.LevelDifficultIncreased -= OnLevelDifficultIncreased;
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

    public void OnLevelCompleted()
    {
        StopCoroutine(_spawnRoutine);
    }

    private void OnLevelDifficultIncreased()
    {
        _startSpawnSeconds = _difficultSpawnSeconds;
    }
}