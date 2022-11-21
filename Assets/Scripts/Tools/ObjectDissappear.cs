using System.Collections;
using UnityEngine;

public sealed class ObjectDissappear : MonoBehaviour
{
    [SerializeField] private float _waitSeconds = 3f;
    
    private void OnEnable() => StartCoroutine(StartDissappearing());

    private IEnumerator StartDissappearing()
    {
        yield return new WaitForSeconds(_waitSeconds);
        gameObject.SetActive(false);
    }
}
