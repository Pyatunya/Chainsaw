using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class EntityCollision : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage = 5;
    private ComboCounter _comboCounter;

    private void OnEnable() => _comboCounter ??= GetComponent<ComboCounter>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            if(health.gameObject.layer == gameObject.layer)
                return;

            StartCoroutine(StartAttacking(health));
        }
    }

    private IEnumerator StartAttacking(Health health)
    {
        yield return new WaitForSeconds(0.2f);
        health.TakeDamage(_damage);
        gameObject.SetActive(false);
        _comboCounter?.ResetToZero();
        Debug.Log("Damage player");
    }
}