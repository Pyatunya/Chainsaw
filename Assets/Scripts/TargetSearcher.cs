using System.Linq;
using UnityEngine;

public sealed class TargetSearcher : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _radius = 1.5f;
    [SerializeField] private LayerMask _layerMask;

    public bool TryFindTarget(out Entity closest)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);

        var entities = colliders.
            Where(collider => collider.GetComponent<Entity>() != null).
            Select(collider => collider.GetComponent<Entity>());

        if (entities == null || entities.Count() == 0)
        {
            closest = null;
            return false;
        }

        closest = null;

        for (int i = 0; i < entities.Count() - 1; i++)
        {
            if (GetDistance(entities.ElementAt(i)) < GetDistance(entities.ElementAt(i + 1)))
            {
                closest = entities.ElementAt(i);
            }
        }

        Debug.Log(closest.gameObject.name);
        return closest != null;

    }

    private float GetDistance(Entity entity)
    {
        Debug.Log((entity.transform.position - transform.position).sqrMagnitude);
        Debug.Log(entity.gameObject.name);
        return (entity.transform.position - transform.position).sqrMagnitude;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.25f);
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
