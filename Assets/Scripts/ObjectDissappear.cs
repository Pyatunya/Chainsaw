using System.Collections;
using UnityEngine;

public sealed class ObjectDissappear : MonoBehaviour
{
    [SerializeField] private float _waitSeconds = 3f;
    
    private IEnumerator OnEnable()
    {
        yield return new WaitForSeconds(_waitSeconds);
        gameObject.SetActive(false);
    }
}
