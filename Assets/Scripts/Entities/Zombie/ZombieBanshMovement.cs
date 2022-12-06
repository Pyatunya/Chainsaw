using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ZombieBanshMovement : Entity
{
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceAttack;
    [SerializeField] private CryFactoroi _cryFactoroi;
    [SerializeField] private float _attackDelay;

    private Vector2 _moveDirection;
    private float _time;
    private Player _player;
    private Rigidbody2D _rigidbody;

    public override Vector2 MoveDirection => _moveDirection;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() => _time += Time.deltaTime;

    private void FixedUpdate()
    {
        if(CanMove == false)
            return;
        
        _moveDirection = (_player.transform.position - transform.position).normalized;

        _rigidbody.MovePosition(_rigidbody.position + _moveDirection * _speed * Time.fixedDeltaTime);

        float distance = (_player.transform.position - transform.position).magnitude;

        if (distance >= _distanceAttack && _time >= _attackDelay)
        {
            _cryFactoroi.Create().Throw(_moveDirection);
            _time = 0;
        }
    }

    public void Init(Player player)
    {
        _player = player;
    }


    protected override void Enable()
    {
    }
}