using System;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private KeyCode _key;

    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            _player.Attack();
        }
    }
}
