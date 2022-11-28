﻿using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public sealed class ZombieCollision : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage = 5;
    [SerializeField] private Zombie _zombie;
    
    private const float AttackDelay = 0.3f;
    private float _inCollisionTime = 0f;

    public event Action OnAttacked;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth player))
        {
            _inCollisionTime += Time.deltaTime;

            if (_inCollisionTime > AttackDelay && gameObject.activeSelf)
            {
                Attack(player.Health);
                _inCollisionTime = 0f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth _))
        {
            _inCollisionTime = 0f;
        }
    }

    private void Attack(Health health)
    {
        OnAttacked?.Invoke();
        _zombie.StopMovement();
        health.TakeDamage(_damage);
       _zombie.ComboCounter.ResetToZero();
    }
}