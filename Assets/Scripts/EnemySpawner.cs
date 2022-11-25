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

    private const float SpawnSecondsOnHardLevelTime = 0.15f;
    private float _spawnSeconds = 0.45f;
    private readonly Dictionary<Entity, IndependentPool<Entity>> _pools = new();
    private Coroutine _spawnRoutine;

    private void OnEnable()
    {
        _levelTimer.HardLevelTimeStarted += OnHardLevelTimeStarted;
        _levelTimer.LevelCompleted += OnLevelCompleted;
    }

    private void OnDisable()
    {
        _levelTimer.HardLevelTimeStarted -= OnHardLevelTimeStarted;
        _levelTimer.LevelCompleted -= OnLevelCompleted;
    }

    private void Start()
    {
        foreach (var prefab in _prefabs)
        {
            _pools.Add(prefab, new IndependentPool<Entity>(new GameObjectsFactory<Entity>(prefab)));
        }

        _spawnRoutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
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

    private void OnLevelCompleted() => StopCoroutine(_spawnRoutine);

    private void OnHardLevelTimeStarted() => _spawnSeconds = SpawnSecondsOnHardLevelTime;
}