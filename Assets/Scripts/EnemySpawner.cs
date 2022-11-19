using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class EnemySpawner : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _spawnSeconds = 1.5f;
    [SerializeField] private Entity[] _prefabs;
    [SerializeField] private float _radius = 1.5f;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnSeconds);
            var prefab = _prefabs[Random.Range(0, _prefabs.Length)];
            Instantiate(prefab, Random.insideUnitCircle * _radius, Quaternion.identity, transform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(Color.magenta.r, Color.magenta.g, Color.magenta.b, 0.25f);
    }
}
