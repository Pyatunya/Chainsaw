using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  sealed class UINavigation : MonoBehaviour
{
    [SerializeField] private Image _posych;
    [SerializeField] private List<Image> _uiElements;
    [SerializeField] private float _needTimeForClick = 1f;
    
    private int _index;
    private float _time;

    private void Start()
    {
        _posych.transform.position = _uiElements[0].transform.position;
    }

    public void Add(Image element) => _uiElements.Add(element);

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            _time += Time.deltaTime;
        }
        
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (_time >= _needTimeForClick)
            {
                if (_uiElements[_index].TryGetComponent(out Button button))
                {
                    button.onClick.Invoke();
                }
            }
            
            else
            {
                _index = GetNextIndex(_index);
                _posych.transform.position = _uiElements[_index].transform.position;
            }

            _time = 0f;
        }
    }

    private int GetNextIndex(int currentIndex)
    {
        if (currentIndex == _uiElements.Count - 1)
        {
           return 0;
        }
        
        else
        {
            if (_uiElements[currentIndex + 1].gameObject.activeInHierarchy == false)
                return GetActiveElementIndex(currentIndex);
            
            return currentIndex + 1;
        }
    }

    private int GetActiveElementIndex(int start)
    {
        if (start == _uiElements.Count - 1)
            return 0;
        
        if (_uiElements[start + 1].gameObject.activeInHierarchy == false)
        {
            start += 1;
            return GetActiveElementIndex(start);
        }
        
        else
        {
            return start;
        }
    }
}