using UnityEngine;

namespace Root
{
    public sealed class Root : MonoBehaviour
    {
        [SerializeField] private BestScore _bestScore;
        [SerializeField] private EnemySpawnerRoot _enemySpawnerRoot;
        [SerializeField] private Health _playerHealth;
        [SerializeField] private PlayerChargingAttackInput[] _playerChargingAttackInputs;
        [SerializeField] private PlayerDashInput _playerDashInput;
        [SerializeField] private Player _player;
        private IUpdateble _playerAttackInput;

#if !UNITY_EDITOR && UNITY_WEBGL
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern bool IsMobile();
#endif
        
        private void Awake()
        {
            var isMobile = false;

#if !UNITY_EDITOR && UNITY_WEBGL
        isMobile = IsMobile();
#endif
            _playerDashInput.Init(isMobile ? KeyCode.Mouse0 : KeyCode.F);
            _playerAttackInput = new PlayerAttackInput(_playerChargingAttackInputs, _player, isMobile ? KeyCode.Mouse0 : KeyCode.F);
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

        private void Update()
        {
            _playerAttackInput.Update(Time.deltaTime);
        }
    }
}