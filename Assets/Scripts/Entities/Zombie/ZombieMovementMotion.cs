﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Zombie))]
public sealed class ZombieMovementMotion : MonoBehaviour
{
    [SerializeField] private ZombieAnimation _zombieAnimator;
    private Zombie _zombie;
    private Coroutine _returnMovement;
    
    private void Start()
    {
        _zombie = GetComponent<Zombie>();
        _zombie.Health.OnDamaged += OnAttacked;
    }

    private void OnAttacked()
    {
        _zombieAnimator.StopAll();
        _zombie.StopMovement();
    }

    private void OnDestroy()
    {
        _zombie.Health.OnDamaged -= OnAttacked;
    }

    private void Update()
    {
        if(_zombie.CanMove)
            return;

        if(_returnMovement != null)
            return;
        
        _returnMovement = StartCoroutine(TryReturnMovement());
    }

    private IEnumerator TryReturnMovement()
    {
        yield return new WaitForSeconds(0.5f);
        _zombieAnimator.Enable();
        _zombie.ContinueMovement();
        _returnMovement = null;
    }
}