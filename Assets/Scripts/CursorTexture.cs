using UnityEngine;

public sealed class CursorTexture : MonoBehaviour
{
    [SerializeField] private Texture2D _texture;
    
    private void OnEnable()
    {
        var texture = new Texture2D(128, 105, TextureFormat.RGBA32, false);
        texture.SetPixels(_texture.GetPixels());
        texture.Apply();
        Cursor.SetCursor(texture, Camera.main.ScreenToViewportPoint(Vector2.zero), CursorMode.ForceSoftware);
        Cursor.visible = true;
    }
}
