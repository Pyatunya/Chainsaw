using System;
using UnityEngine;

[Serializable]
public struct ZombieWaveData
{
    [field: SerializeField] public Zombie[] Prefabs { get; private set; }
    
    [field: SerializeField] public float NeedTimeToStart { get; private set; }
}