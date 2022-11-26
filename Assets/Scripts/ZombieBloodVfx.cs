using UnityEngine;

public class ZombieBloodVfx : MonoBehaviour
{
    [SerializeField] private Zombie _zombie;
    [SerializeField] private ParticleSystem _bloodVfx;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.OnDied += OnDied;
    }

    private void OnDisable()
    {
        _health.OnDied -= OnDied;
    }

    public void OnDied()
    {
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, _zombie.MoveDirection);
        Instantiate(_bloodVfx, transform.position, rotation).Play();
    }
}