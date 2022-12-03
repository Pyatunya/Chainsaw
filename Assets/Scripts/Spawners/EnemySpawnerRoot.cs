using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class EnemySpawnerRoot : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] _spawners;

    private const float BeforeGameStartedSeconds = 2f;
    private const float SpawnSeconds = 1.25f;

    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(BeforeGameStartedSeconds);

        while (true)
        {
            yield return new WaitForSeconds(SpawnSeconds);
            var spawner = _spawners[Random.Range(0, _spawners.Length)];
            spawner.Create();
        }
    }
}