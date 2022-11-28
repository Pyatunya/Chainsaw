using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{
    public abstract IEntity Create();
}