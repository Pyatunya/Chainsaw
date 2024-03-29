﻿using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class IndependentPool<T> : IPool<T> where T : MonoBehaviour
{
    private readonly IPool<T> _pool;
    private readonly IGameObjectsContainerFactory<T> _factory;

    public IndependentPool(GameObjectsFactory<T> gameObjectsFactory)
    {
        if (gameObjectsFactory is null)
            throw new ArgumentNullException(nameof(gameObjectsFactory));

        _factory = new GameObjectsContainerFactory<T>(gameObjectsFactory);
        _pool = new Pool<T>(_factory);
    }

    private IEnumerable<T> CreatedObjects => _factory.CreatedObjects;

    public void Release(T obj) => _pool.Release(obj);

    public T Get()
    {
        // foreach (var item in CreatedObjects)
        // {
        //     if (item.gameObject.activeInHierarchy == false)
        //     {
        //         Release(item);
        //     }
        // }

        return _pool.Get();
    }
}