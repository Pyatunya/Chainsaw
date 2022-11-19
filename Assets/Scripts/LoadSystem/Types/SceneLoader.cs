using UnityEngine;

namespace Shooter.LoadSystem
{
    public sealed class SceneLoader : MonoBehaviour, ISceneLoader
    {
        [SerializeField] private SceneLoadMode _mode;
        [SerializeField] private SceneData _loaderScene;
        
        public void Load(SceneData sceneData)
        {
            IFactory<ISceneLoader> factory = new SceneLoaderFactory(_mode, _loaderScene);
            var sceneLoader = factory.Create();
            sceneLoader.Load(sceneData);
        }
    }
}