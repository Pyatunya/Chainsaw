using UnityEngine;

[RequireComponent(typeof(Button))]
public sealed class ExitButton : Button
{
    protected override void OnClick()
    {
        Exit();
    }

    private void Exit()
    {
        Application.Quit();
    }
}
