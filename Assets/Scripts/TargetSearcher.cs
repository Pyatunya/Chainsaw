using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class TargetSearcher : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    public bool TryFindTarget(out Entity closest)
    {
        IEnumerable<Entity> entities = FindInCircle();

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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);

        var entities = colliders.
            Where(collider => collider.GetComponent<Entity>() != null).
            Select(collider => collider.GetComponent<Entity>());

        return entities;
    }

    private Entity FindClosest(IEnumerable<Entity> entities)
    {
        Entity closest = entities.ElementAt(0);
        float closestDistance = Vector3.Distance(transform.position, entities.ElementAt(0).transform.position);

        for (int i = 0; i < entities.Count(); i++)
        {
            float distance = Vector3.Distance(transform.position, entities.ElementAt(i).transform.position);

            if (distance < closestDistance)
            {
                closest = entities.ElementAt(i);
            }
        }

        return closest;
    }
}
