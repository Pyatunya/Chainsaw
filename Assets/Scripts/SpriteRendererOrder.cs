using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererOrder : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Transform _parent;
    private float _roundingValue = 100f;

    public void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _parent = GetComponentInParent<Transform>();
    }

    private void Update()
    {
        _sprite.sortingOrder = (int)(_parent.transform.position.y * -_roundingValue);
    }
}