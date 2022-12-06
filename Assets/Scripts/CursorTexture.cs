using UnityEngine;

public sealed class CursorTexture : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;

    private void Update()
    {
        var newTexture = new Texture2D(128, 105, TextureFormat.RGBA32, false);
        newTexture.SetPixels(_texture.GetPixels());
        newTexture.Apply();
        Cursor.SetCursor(newTexture, new Vector2(100, 75), CursorMode.ForceSoftware);
        Cursor.visible = true;
    }
}