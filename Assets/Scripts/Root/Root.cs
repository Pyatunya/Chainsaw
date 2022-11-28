using UnityEngine;

namespace Root
{
    public sealed class Root : MonoBehaviour
    {
        [SerializeField] private BestScore _bestScore;
        [SerializeField] private EnemySpawnerRoot _enemySpawnerRoot;
        [SerializeField] private Health _playerHealth;

        private void Awake()
        {
            InitPlayer();
            InitBestScore();
            _enemySpawnerRoot.StartSpawn();
        }

        private void InitBestScore()
        {
            var recordStorage = new StorageWithNameSaveObject<BestScore, int>();
            var record = recordStorage.HasSave() ? recordStorage.Load() : 0;
            _bestScore.Init(record);
        }

        private void InitPlayer()
        {
            var healthMaxCountStorage = new StorageWithNameSaveObject<Health, int>();
            var maxHealth = healthMaxCountStorage.HasSave() ? healthMaxCountStorage.Load() : 10;
            _playerHealth.Init(maxHealth);
        }
    }
}