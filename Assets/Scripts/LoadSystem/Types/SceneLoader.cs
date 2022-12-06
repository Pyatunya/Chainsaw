using UnityEngine;

namespace Shooter.LoadSystem
{
    public sealed class SceneLoader : MonoBehaviour, ISceneLoader
    {
        [SerializeField] private SceneLoadMode _mode;
        [SerializeField] private SceneData _loadingScreen;
        private IFactory<ISceneLoader> _sceneLoaderFactory;

        private void Awake()
        {
            _sceneLoaderFactory = new SceneLoaderFactory(_mode, _loadingScreen);
        }

        public void Load(SceneData sceneData)
        {
            var sceneLoader = _sceneLoaderFactory.Create();
            sceneLoader.Load(sceneData);
        }
    }
}