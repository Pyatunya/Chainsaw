using UnityEngine;

public class CryFactoroi : MonoBehaviour
{
    [SerializeField] private Cry _cryFrefab;
    [SerializeField] private Transform _spawnPoint;

    public Cry Create()
    {
        return Instantiate(_cryFrefab, _spawnPoint.position, Quaternion.identity, transform);
    }
}
