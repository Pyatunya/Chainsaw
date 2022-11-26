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
        ChangeLoadText();
        _loadScreen.completed -= LoadNext;
    }

    private async void ChangeLoadText()
    {
        var time = 0f;
        
        while (time < 2f)
        {
            await Task.Yield();
            Visualize(Mathf.Lerp(0, 1, time / 2f));
            time += Time.deltaTime;
        }
        
        _nextSceneLoad = SceneManager.LoadSceneAsync(_nextScene.Name);
        while (!_nextSceneLoad.isDone)
        {
            await Task.Yield();
            Visualize(_nextSceneLoad.progress);
        }
    }

    private void Visualize(float progress)
    {
        LoadingInterest.Visualize(progress);
        LoadingBar.Visualize(progress);
    }
}