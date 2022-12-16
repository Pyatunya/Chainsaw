using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class UINavigation : MonoBehaviour
{
    [SerializeField] private List<Image> _uiElements;
    [SerializeField] private float _needTimeForClick = 0.5f;
    [SerializeField] private UiNavigationCursor _cursor;
    
    private readonly UINavigationIndex _navigationIndex = new();
    private int _index;
    private float _time;

    private void Start() => _cursor.TranslateTo(_uiElements[0].transform.position);

    public void Add(Image element) => _uiElements.Add(element);

    private void Update()
    {
        if (gameObject.activeInHierarchy == false)
            return;

        if (Input.GetKey(KeyCode.F))
        {
            _time += Time.unscaledDeltaTime;
            var minTimeToPlayAnimation = 0.15f;
            
            if (_time >= minTimeToPlayAnimation)
                _cursor.PlayAnimation();
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            _cursor.StopAnimation();
            
            if (_time >= _needTimeForClick)
            {
                if (_uiElements[_index].gameObject.TryGetComponent(out UnityEngine.UI.Button button))
                {
                    button.onClick.Invoke();
                }
            }

            else
            {
                _index = _navigationIndex.GetNextFrom(_uiElements, _index);
                _cursor.TranslateTo(_uiElements[_index].transform.position);
            }

            _time = 0f;
        }
    }
}