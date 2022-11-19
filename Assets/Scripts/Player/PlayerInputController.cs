using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private float dashChargeTime = 0.5f;
    [SerializeField] private DashSecondsView _dashSecondsView;

    private readonly KeyCode _key = KeyCode.F;
    private Player _player;
    private float _time;

    private void Awake() => _player = GetComponent<Player>();

    private void Update()
    {
        ChargeDash();

        if (Input.GetKeyUp(_key))
        {
            if (_time >= dashChargeTime)
                _player.Dash();
            else
                _player.Attack();

            _time = 0;
        }
    }

    private void ChargeDash()
    {
        _dashSecondsView.Visualize(_time);
        if (Input.GetKey(_key))
        {
            _time += Time.deltaTime;
        }
    }
}