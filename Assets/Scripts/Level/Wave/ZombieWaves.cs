using System.Collections.Generic;
using UnityEngine;

public sealed class ZombieWaves : MonoBehaviour
{
    [SerializeField] private ZombieSpawner _zombieSpawner;
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private List<ZombieWaveData> _waveData;

    private void Awake()
    {
       _zombieSpawner.SwitchPrefabs(_waveData[0].Prefabs);
    }

    private void Update()
    {
        var waveData = _waveData.FindLast(data => data.NeedTimeToStart <= _levelTimer.Time);
        if(_zombieSpawner.Prefabs != waveData.Prefabs)
            _zombieSpawner.SwitchPrefabs(waveData.Prefabs);
    }
}