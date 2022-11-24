using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Zombie : Entity
{
    private LevelTimer _levelTimer;
    private float _speed = 4f;
    private float _speedDifficult = 10f;
    private Player _player;
    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        if (_levelTimer.IsDifficultPhase)
            _speed = _speedDifficult;
    }

    private void Awake()
    {
        _rigidbody ??= GetComponent<Rigidbody2D>();
        _player ??= FindObjectOfType<Player>();
        _levelTimer ??= FindObjectOfType<LevelTimer>();
        _levelTimer.LevelDifficultIncreased += OnLevelDifficultIncreased;
    }

    private void OnDisable()
    {
        _levelTimer.LevelDifficultIncreased -= OnLevelDifficultIncreased;
    }

    private void FixedUpdate()
    {
        if (_player == null)
            return;

        Vector2 direction = (_player.transform.position - transform.position).normalized;
        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.fixedDeltaTime);
    }

    private void OnLevelDifficultIncreased()
    {
        _speed = _speedDifficult;
        Debug.Log(_speed);
    }
}