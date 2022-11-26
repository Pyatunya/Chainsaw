using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class Zombie : Entity
{
    private const float SpeedOnHardLevelTime = 10f;
    private float _speed = 4f;
    private Player _player;
    private Rigidbody2D _rigidbody;
    private LevelTimer _levelTimer;
    
    public bool CanMove { get; private set; }

    public Vector2 MoveDirection { get; private set; }

    private void Awake() => _levelTimer ??= FindObjectOfType<LevelTimer>();

    public void StopMovement() => CanMove = false;

    public void ContinueMovement() => CanMove = true;

    protected override void Enable()
    {
        if (_levelTimer.IsHardLevel)
            _speed = SpeedOnHardLevelTime;
    }

    private void Start()
    {
        _rigidbody ??= GetComponent<Rigidbody2D>();
        _player ??= FindObjectOfType<Player>();
    }

    private void FixedUpdate()
    {
        if (_player == null || CanMove == false)
            return;

        Vector2 direction = (_player.transform.position - transform.position).normalized;
        MoveDirection = direction;
        _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.fixedDeltaTime);
    }
}