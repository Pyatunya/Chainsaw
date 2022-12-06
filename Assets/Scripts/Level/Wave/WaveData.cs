using System;
using UnityEngine;

[Serializable]
public struct WaveData
{
    [field: SerializeField] public EnemySpawner[] Spawners { get; private set; }
    
    [field: SerializeField] public float NeedTimeToStart { get; private set; }

    [field: SerializeField] public int EnemySpawnCountAtOnce { get; private set; }
}