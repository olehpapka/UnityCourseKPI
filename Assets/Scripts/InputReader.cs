using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private AnimationController _animationController;

    private float _direction;
    private void Update()
    {
        
        _direction = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && _playerMovement.IsGrounded())
            _playerMovement.Jump();

        _animationController.UpdatePlayerState(_direction);

    }

    private void FixedUpdate()
    {
        _playerMovement.MoveHorizontally(_direction);
    }
}
