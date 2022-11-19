using System.Linq;
using UnityEngine;

public sealed class TargetSearcher : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _radius = 1.5f;
    [SerializeField] private LayerMask _layerMask;

    private void Start()
    {
        TryFindTarget(out var en);
    }

    public bool TryFindTarget(out Entity closest)
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);

        var entities = colliders.Where(collider => collider.GetComponent<Entity>() != null).
                Select(collider => collider.GetComponent<Entity>());

        if (entities == null || entities.Count() == 0)
        {
            closest = null;
            return false;
        }
        
        closest = entities.ElementAt(0);
        
        for (var i = 0; i < entities.Count(); i++)
        {
            if(i + 1 == entities.Count() - 1)
                break;
            
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
        return (transform.position - entity.transform.position).sqrMagnitude;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
