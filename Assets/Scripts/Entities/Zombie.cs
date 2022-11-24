using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Zombie : Entity
{
    private float _speed = 4f;
    private float _speedOnHardLevelTime = 10f;
    private Player _player;
    private Rigidbody2D _rigidbody;
    private LevelTimer _levelTimer;

    private void Awake()
    {
        _levelTimer ??= FindObjectOfType<LevelTimer>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        if (_levelTimer.IsHardLevel)
            _speed = _speedOnHardLevelTime;
    }

    private void Start()
    {
        _rigidbody ??= GetComponent<Rigidbody2D>();
        _player ??= FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        if (_player == null)
            return;

        Vector2 direction = (_player.transform.position - transform.position).normalized;
        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.fixedDeltaTime);
    }
}