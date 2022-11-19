using System;
using System.ComponentModel;

public sealed class SceneLoaderFactory : IFactory<ISceneLoader>
{
    private readonly SceneLoadMode _sceneLoadMode;
    private readonly IScreenFade _screenFade;
    private readonly SceneData _loaderScene;

    public SceneLoaderFactory(SceneLoadMode sceneLoadMode, SceneData loaderScene)
    {
        if (!Enum.IsDefined(typeof(SceneLoadMode), sceneLoadMode))
            throw new InvalidEnumArgumentException(nameof(sceneLoadMode), (int)sceneLoadMode, typeof(SceneLoadMode));

        _sceneLoadMode = sceneLoadMode;
        _loaderScene = loaderScene;
    }


    public ISceneLoader Create()
    {
        return _sceneLoadMode switch
        {
            SceneLoadMode.Simple => new StandartSceneLoader(),
            SceneLoadMode.WithLoadScreen => new SceneLoaderWithScreen(_loaderScene),
            _ => throw new ArgumentOutOfRangeException(nameof(_sceneLoadMode))
        };
    }
}