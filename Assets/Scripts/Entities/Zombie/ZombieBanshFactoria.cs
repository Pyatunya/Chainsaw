using UnityEngine;

class ZombieBanshFactoria : EnemySpawner
{
    [SerializeField] private ZombieBanshMovement _zombiePrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Player _player;

    public override IEntity Create()
    {
        Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        var zombie = Instantiate(_zombiePrefab, randomSpawnPoint.transform.position, Quaternion.identity);
        zombie.Init(_player);

        return zombie;
    }
}