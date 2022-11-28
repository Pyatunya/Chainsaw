using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class EnemySpawnerRoot : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] _spawners;
    [SerializeField] private LevelTimer _levelTimer;

    private const float SpawnSecondsOnHardLevelTime = 0.15f;
    private const float SpawnDelayOnLevelStart = 2f;
    private float _spawnSeconds = 0.45f;
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
        _spawnRoutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(SpawnDelayOnLevelStart);

        while (true)
        {
            yield return new WaitForSeconds(_spawnSeconds);
            var spawner = _spawners[Random.Range(0, _spawners.Length)];
            spawner.Create();
        }
    }

    private void OnLevelCompleted() => StopCoroutine(_spawnRoutine);

    private void OnHardLevelTimeStarted() => _spawnSeconds = SpawnSecondsOnHardLevelTime;
}