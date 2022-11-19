using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading.Tasks;

public sealed class SceneLoaderWithScreen : ISceneLoader
{
    private readonly SceneData _loaderScene;
    private AsyncOperation _loadScreen;
    private AsyncOperation _nextSceneLoad;
    private SceneData _nextScene;

    public SceneLoaderWithScreen(SceneData loaderScene) => _loaderScene = loaderScene ?? throw new ArgumentNullException(nameof(loaderScene));

    public void Load(SceneData sceneData)
    {
        _loadScreen = SceneManager.LoadSceneAsync(_loaderScene.Name, LoadSceneMode.Additive);
        _nextScene = sceneData;
        _loadScreen.completed += LoadNext;
    }

    private void LoadNext(AsyncOperation operation)
    {
        _nextSceneLoad = SceneManager.LoadSceneAsync(_nextScene.Name);
        ChangeLoadText();
        _loadScreen.completed -= LoadNext;
    }

    private async void ChangeLoadText()
    {
        while (!_nextSceneLoad.isDone)
        {
            await Task.Yield();
            LoadText.SetInterest(_nextSceneLoad.progress);
        }
    }
}