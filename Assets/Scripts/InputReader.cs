using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private float _direction;
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            _playerMovement.Jump();
        _direction = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        _playerMovement.MoveHorizontally(_direction);
    }
}
