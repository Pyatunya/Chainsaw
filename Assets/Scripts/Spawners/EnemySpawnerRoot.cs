using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class EnemySpawnerRoot : MonoBehaviour
{
    private const float SpawnDelay = 2f;
    private const float SpawnSeconds = 0.45f;

    public WaveData WaveData { get; private set; }
    
    public void StartSpawn() => StartCoroutine(Spawn());

    public void SwitchWave(WaveData waveData)
    {
        WaveData = waveData;
    }
    
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(SpawnDelay);

        while (true)
        {
            for (var i = 0; i < WaveData.EnemySpawnCountAtOnce; i++)
            {
                yield return new WaitForSeconds(SpawnSeconds);
                var spawners = WaveData.Spawners;
                var spawner = spawners[Random.Range(0, spawners.Length)];
                spawner.Create();
                
            }
        }
    }
}