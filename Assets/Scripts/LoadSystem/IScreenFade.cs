using System;

public interface IScreenFade
{
    event Action OnDarkened;

    void FadeIn();

    void FadeOut();
}