using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class TargetSearcher : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _radius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;

    public void ZombieSearch(out Collider2D[] hitEnemies)
    {
        hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _layerMask);
    }

    public bool TryFindTarget(out Entity closest)
    {
        var entities = FindInCircle();

        if (entities == null || entities.Count() == 0)
        {
            closest = null;
            return false;
        }

        closest = FindClosest(entities);
        return closest != null;
    }

    private IEnumerable<Entity> FindInCircle()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);

        var entities = colliders.
            Where(collider => collider.GetComponent<Entity>() != null).
            Select(collider => collider.GetComponent<Entity>());

        return entities;
    }

    private Entity FindClosest(IEnumerable<Entity> entities)
    {
        var closest = entities.ElementAt(0);
        var closestDistance = Vector3.Distance(transform.position, entities.ElementAt(0).transform.position);

        for (var i = 0; i < entities.Count(); i++)
        {
            var distance = Vector3.Distance(transform.position, entities.ElementAt(i).transform.position);

            if (distance < closestDistance)
            {
                closest = entities.ElementAt(i);
            }
        }

        return closest;
    }
}
