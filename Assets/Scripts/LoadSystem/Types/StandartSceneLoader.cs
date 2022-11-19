using UnityEngine.SceneManagement;

public sealed class StandartSceneLoader : ISceneLoader
{
    public void Load(SceneData sceneData) => SceneManager.LoadSceneAsync(sceneData.Name);
}