using UnityEngine;

public class Entity : MonoBehaviour
{
    public void Die()
    {
        Destroy(gameObject);
    }
}