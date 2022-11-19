using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private DashSecondsView _dashSecondsView;
    private readonly KeyCode _key = KeyCode.F;
    private Player _player;
    private float _time;

    private void Awake() => _player = GetComponent<Player>();

    private void Update()
    {
        // if (Input.GetKeyDown(_key))
        // {
        //     _player.Attack();
        // }

        _dashSecondsView.Visualize(_time);
        if (Input.GetKey(_key))
        {
            _time += Time.deltaTime;
        }

        if (Input.GetKeyUp(_key) && _time >= 3)
        {
            _time = 0;
            _player.Dash();
        }
    }
}