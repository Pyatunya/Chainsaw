using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyWaves : MonoBehaviour
{
    [SerializeField] private EnemySpawnerRoot  _enemySpawnerRoot;
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private List<WaveData> _waveData;

    private void Awake()
    {
       _enemySpawnerRoot.SwitchWave(_waveData[0]);
    }
    
    private void Update()
    {
        var waveData = _waveData.FindLast(data => data.NeedTimeToStart <= _levelTimer.Time1);
        
        if(_enemySpawnerRoot.WaveData.Spawners == waveData.Spawners)
            return;
        
        _enemySpawnerRoot.SwitchWave(waveData);
    }
}