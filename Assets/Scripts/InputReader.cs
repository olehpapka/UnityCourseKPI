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
        
        _direction = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && _playerMovement.IsGrounded())
            _playerMovement.Jump();
    }

    private void FixedUpdate()
    {
        _playerMovement.MoveHorizontally(_direction);
    }
}
