using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class EnemySpawnerRoot : MonoBehaviour
{
    private const float SpawnDelayOnLevelStart = 2f;
    private const float SpawnSeconds = 0.45f;

    public WaveData WaveData { get; private set; }

    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(SpawnDelayOnLevelStart);

        while (true)
        {
            yield return new WaitForSeconds(SpawnSeconds);
            var spawner = WaveData.Spawners[Random.Range(0, WaveData.Spawners.Length)];
            spawner.Create();
        }
    }

    public void SwitchWave(WaveData waveData)
    {
        WaveData = waveData;
    }
}